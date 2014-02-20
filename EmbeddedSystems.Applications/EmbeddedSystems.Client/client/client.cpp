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

    network = new Network();

    QObject::connect(this, SIGNAL(request(QUrl)), network, SLOT(getRequest(QUrl)));
    QObject::connect(network, SIGNAL(forwardMessage(QString)), this, SLOT(networkReply(QString)));

    QThread* netThread = new QThread();

    QObject::connect(netThread, SIGNAL(started()), network, SLOT(begin()));
    QObject::connect(network, SIGNAL(networkFinished()), netThread, SLOT(quit()));

    network->moveToThread(netThread);
    netThread->start();

    network->begin();

    // we need to authenticate the handset before we can do anything
    while (!authenticated)
    {
        authenticated = authenticateDevice();
    }
    qDebug() << "Authenticated";


    tracker.startTracking();
}

/*
 *  Send request to authenticate with device's MAC and 4 digit keycode
 *  Return true or false
 */
bool Client::authenticateDevice()
{
    bool success;
   qDebug() << "Authenticating";
  //  QString reply = network->getRequest(handsetApiUrl);
   emit request(handsetApiUrl);
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
    QVector<QStringList> parsedResponse;
    QStringList lines = reply.split(" ");

    foreach (QString line, lines)
    {
        qDebug() << "l " << line << "\n\n";
    }

// TODO
//   QScriptValue sc;
//       QScriptEngine engine;
//       sc = engine.evaluate(reply); // In new versions it may need to look like engine.evaluate("(" + QString(result) + ")");

//       if (sc.property("result").isArray())
//       {

//               QStringList items;
//               qScriptValueToSequence(sc.property("result"), items);

//               foreach (QString str, items) {
//                    qDebug("value %s",str.toStdString().c_str());
//                }

//       }


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
    }
}

void Client::networkReply(QString theReply)
{
    reply = theReply; // TODO
    qDebug() << "networkReply";
    setWaitOver(true);
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
