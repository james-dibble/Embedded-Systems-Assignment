#include "client.h"

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


    // setup location tracker thread
    tracker = new LocationTracker();

 //   QObject::connect(this, SIGNAL(request(QUrl, QString)), network, SLOT(getRequest(QUrl, QString)));
    QObject::connect(tracker, SIGNAL(forwardNewLocation(QString)), this, SLOT(locationChanged(QString)));
    QThread* trackerThread = new QThread();
    QObject::connect(trackerThread, SIGNAL(started()), tracker, SLOT(startTracking()));
    QObject::connect(tracker, SIGNAL(trackerFinished()), trackerThread, SLOT(quit()));

    tracker->moveToThread(trackerThread);
    trackerThread->start();
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
        success = true;
    //#else
    //    success = false;
    //#endif
    return success;
}

bool Client::parseResponse()
{
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

void Client::buttonPressed(KeypadButton button)
{
    if (!authenticated)
    {
        // we shouldnt do anything
        return;
    }

    switch (button)
    {
    case KeypadButton::KEY_1:
        requestExhibit(1); break;
    case KeypadButton::KEY_2:
        requestExhibit(2); break;
    case KeypadButton::KEY_3:
        requestExhibit(3); break;
    case KeypadButton::KEY_4:
        requestExhibit(4); break;
    case KeypadButton::KEY_5:
        requestExhibit(5); break;
    case KeypadButton::KEY_6:
        requestExhibit(6); break;
    case KeypadButton::KEY_7:
        requestExhibit(7); break;
    case KeypadButton::KEY_8:
        requestExhibit(8); break;
    case KeypadButton::KEY_9:
        requestExhibit(9); break;
    case KeypadButton::KEY_0:
        requestExhibit(0); break;
    case KeypadButton::KEY_A: // play/pause button
        playPause(); break;
    case KeypadButton::KEY_B: // fast forward button
        fastForward(); break;
    case KeypadButton::KEY_C: // rewind button
        rewind(); break;
    case KeypadButton::KEY_D:
        qDebug() << "Not implemented"; break;
    case KeypadButton::KEY_E:
        qDebug() << "Not implemented"; break;
    case KeypadButton::KEY_F:
        qDebug() << "Not implemented"; break;
    default /*NONE*/:
        qWarning() << "Bad key press!"; break;
    }
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

void Client::playPause()
{

}

void Client::fastForward()
{

}

void Client::rewind()
{

}

void Client::requestExhibit(int exhibit)
{
    if (exhibit == 1)
    {
        emit request(handsetApiUrl);
        blockOnReply();
        qDebug() << "end block";

        parseResponse();
    }

}

void Client::locationChanged(QString)
{

}
