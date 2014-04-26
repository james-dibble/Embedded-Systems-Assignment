#include "client.h"
#include "locationtracker.h"

extern const QString baseUrl;
extern const QString handsetApiUrl;

Client::Client(QObject *parent) :
    QObject(parent)
{
}

Client::~Client()
{
    delete network;
}

void Client::startClient()
{
    LocationTracker tracker;
    authenticated = false;

    keypad = new KeypadController();

    QObject::connect(this, SIGNAL(getPin(QString&)), keypad, SLOT(pinRequested(QString&)),Qt::BlockingQueuedConnection);
    QObject::connect(keypad, SIGNAL(forwardButton(KeypadButton)), this, SLOT(buttonPressed(KeypadButton)));
    QThread* keypadThread = new QThread();
    QObject::connect(keypadThread, SIGNAL(started()), keypad, SLOT(start()));
    QObject::connect(keypad, SIGNAL(keypadFinished()), keypadThread, SLOT(quit()));

    keypad->moveToThread(keypadThread);
    keypadThread->start();

    // network lives in a thread so hook up signals
    network = new Network();

    QObject::connect(this, SIGNAL(request(QUrl, QString)), network, SLOT(getRequest(QUrl, QString)));
    QObject::connect(network, SIGNAL(forwardMessage(QString, unsigned int)), this, SLOT(networkReply(QString, unsigned int)));
    QThread* netThread = new QThread();
    QObject::connect(netThread, SIGNAL(started()), network, SLOT(begin()));
    QObject::connect(network, SIGNAL(networkFinished()), netThread, SLOT(quit()));

    network->moveToThread(netThread);
    netThread->start();

    QMetaObject::invokeMethod(network,"begin");
    //network->begin();

    // we need to authenticate the handset before we can do anything
    while (!authenticated)
    {
        authenticated = authenticateDevice();
    }
    qDebug() << "Authenticated";

    emit request(handsetApiUrl);
    blockOnReply();
    qDebug() << "end block";

    parseResponse();

    tracker.startTracking();
}

/*
 *  Send request to authenticate with device's MAC and 4 digit keycode
 *  Return true or false
 */
bool Client::authenticateDevice()
{
    bool success;
    QString pincode = "";
   // int newPin = 0;

    qWarning() << "Enter 4 digit pin on keypad";
    emit getPin(pincode);
//    newPin = keypad->getPin();

    qDebug() << "Authenticating";
    //  QString reply = network->getRequest(handsetApiUrl);
    emit request(handsetApiUrl, pincode);
    //  QMetaObject::invokeMethod(network,"getRequest",Q_ARG(QUrl, handsetApiUrl));

    // block thread until reply receieved
    blockOnReply();
    qDebug() << "end block";

    success = parseResponse();
    //#ifdef DEBUG
    //    success = true;
    //#else
    //    success = false;
    //#endif
    return success;
}

bool Client::parseResponse()
{
//    QVector<QStringList> parsedResponse;
//    QStringList lines;

//    lines = reply.split("\n");

//    // split each line into words
//    foreach (QString line, lines)
//    {
//        QStringList words;
//        words = line.split(' ');
//        parsedResponse.push_back(words);
//    }

    if (httpCode != 200)
    {
        qWarning() << "Authentication error";
        return false;
    }

    if (reply.isEmpty())
    {
        qDebug() << "Empty message, not a problem";
        return true;
    }

    qDebug() << "its parsing time";

    const std::string stdreply = reply.toStdString();
    Json::Value yes;
    Json::Reader reader;
  //  Json::
    if (!(reader.parse(stdreply, yes, true)))
    {
        // parsing failed
        qDebug() << reader.getFormattedErrorMessages().c_str();
    }

    int pints = yes.get("ExhibitId", -1).asInt();
    qDebug() << "Exhibit is " << pints;

    std::string file = yes.get("FilePath", "ERROR ERROR ERROR ERROR ERROR").asString();
    qDebug() << "FilePath is " << file.c_str();

qDebug() << "done";
    return true;
}

//QStringList Client::splitString(QString str)
//{
//    return str.split("\n");
//}

//void Client::splitLine()
//{

//}

void Client::blockOnReply()
{
    setWaitOver(false);

    while (getWaitOver() == false)
    {
       QCoreApplication::processEvents();
    //   qDebug() << "Blocked";
    }
}

void Client::networkReply(QString theReply, unsigned int statusCode)
{
    reply = theReply; // TODO
    httpCode = statusCode;
    qDebug() << "networkReply";
    setWaitOver(true);
}

void Client::buttonPressed(KeypadButton)
{

}

bool Client::getWaitOver()
{
    QMutexLocker locker(&clientMutex);
  //  qDebug() << "get ";
    return waitOver;
}

void Client::setWaitOver(bool newWait)
{
    QMutexLocker locker(&clientMutex);
    qDebug() << "set " << newWait;
    waitOver = newWait;
}
