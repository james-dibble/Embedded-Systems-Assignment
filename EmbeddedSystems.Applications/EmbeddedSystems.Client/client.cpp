#include "client.h"

extern const QString baseUrl;
extern const QString handsetApiUrl;

Client::Client(QObject *parent) :
    QObject(parent)
{
}

Client::~Client()
{
    delete tracker;
    delete mediaPlayer;
    delete keypad;
//    delete lcd;
    delete network;
}

void Client::startClient()
{
    setup();

    QThread* keypadThread = new QThread();
    QObject::connect(keypadThread, SIGNAL(started()), keypad, SLOT(start()));
    QObject::connect(keypad, SIGNAL(keypadFinished()), keypadThread, SLOT(quit()));
    QObject::connect(keypad, SIGNAL(keypadFinished()), keypadThread, SLOT(quit()));
    QObject::connect(keypadThread, SIGNAL(finished()), this, SLOT(noKeypad()));

    keypad->moveToThread(keypadThread);
    keypadThread->start();

    QThread* netThread = new QThread();
    QObject::connect(netThread, SIGNAL(started()), network, SLOT(begin()));
    QObject::connect(network, SIGNAL(networkFinished()), netThread, SLOT(quit()));

    network->moveToThread(netThread);
    netThread->start();
    // QMetaObject::invokeMethod(network,"begin");

    // we need to authenticate the handset before we can do anything
    while (!authenticated && !error)
    {
        authenticated = authenticateDevice();
    }
    if (error)
    {
        // put quit onto event queue
        QMetaObject::invokeMethod(this, "forceQuit", Qt::QueuedConnection);
        return;
    }
    qDebug() << "Authenticated";


    QThread* trackerThread = new QThread();
    QObject::connect(trackerThread, SIGNAL(started()), tracker, SLOT(startTracking()));
    QObject::connect(tracker, SIGNAL(trackerFinished()), trackerThread, SLOT(quit()));

    tracker->moveToThread(trackerThread);
    trackerThread->start();
}

void Client::setup()
{
    authenticated = false;
    error = false;

    buttonTimeout = new QTimer(this);
    connect(buttonTimeout,SIGNAL(timeout()),this,SLOT(exhibitNumberEntered()));
    buttonTimeout->setSingleShot(true);

//    lcd = new LcdController();
    mediaPlayer = new MediaPlayer();
    keypad = new KeypadController();

    // must register own types or Qt wont connect them properly
    qRegisterMetaType<KeypadButton>("KeypadButton");

    QObject::connect(this, SIGNAL(getPin()), keypad, SLOT(pinRequested()));
    QObject::connect(keypad, SIGNAL(forwardButton(KeypadButton)), this, SLOT(buttonPressed(KeypadButton)));
    QObject::connect(keypad, SIGNAL(forwardPincode(QString)), this, SLOT(pincodeReceived(QString)));

    // network lives in a thread so hook up signals
    network = new Network();
    QObject::connect(this, SIGNAL(request(QUrl, QString)), network, SLOT(getRequest(QUrl, QString)));
    QObject::connect(network, SIGNAL(forwardMessage(QString, unsigned int)), this, SLOT(networkReply(QString, unsigned int)));

    // setup location tracker thread
    tracker = new LocationTracker();
    QObject::connect(tracker, SIGNAL(forwardNewLocation(int)), this, SLOT(locationChanged(int)));
}

/*
 *  Send request to authenticate with device's MAC and 4 digit keycode
 *  Return true or false
 */
bool Client::authenticateDevice()
{
    bool success;
    pincode = "";

    qWarning() << "Enter 4 digit pin on keypad";
    emit getPin();
    blockOnPincode();

    if (error)
    {
        return false;
    }

#if DEBUG
    // force pincode
    pincode = "6377";
#endif

    qDebug() << "Authenticating";
    emit request(authenticateUrl, pincode);

    // block thread until reply receieved
    blockOnReply();
    qDebug() << "end block";

    success = parseResponse();
    //#ifdef DEBUG
    //    success = true;
    //#else
    //    success = false;
    //#endif

#if DEBUG
  //  requestExhibit(1);
#endif
    return success;
}

bool Client::parseResponse()
{
    if (httpCode < 200 || httpCode > 202)
    {
        qWarning() << "Authentication error";
        return false;
    }

    if (reply.isEmpty() && !authenticated)
    {
        qDebug() << "Empty message, not a problem";
        return true;
    }

    qDebug() << "its parsing time";

    const std::string stdreply = reply.toStdString();
    Json::Value root;
    Json::Reader reader;

    if (!(reader.parse(stdreply, root, true)))
    {
        // parsing failed
        qDebug() << reader.getFormattedErrorMessages().c_str();
    }

    int pints = root.get("ExhibitId", -1).asInt();
    qDebug() << "Exhibit is " << pints;

    std::string filePath = root.get("FilePath", "NULL").asString();
    qDebug() << "FilePath is " << filePath.c_str();
    // something like:
    // C:\wmpub\wmroot\esd\Kalimba.mp3
    int slashPos = filePath.find_last_of('\\');
    std::string actualFile = filePath.substr(slashPos+1);
    file = actualFile.c_str();
    qDebug() << "File is " << file;

    return true;
}

void Client::requestExhibit(int exhibit)
{
    QString requestString = fileRequestUrl;
    QString exhibitString = QString("%1").arg(exhibit);
    requestString.append(exhibitString);
    qDebug() << requestString << " " << exhibit;
    emit request(requestString);
    blockOnReply();
    qDebug() << "end block";

    if (!parseResponse())
    {
        // error parsing
        qWarning("Error on server");
        return;
    }

    QString url = mmsBaseUrl;
    url.append(file);
//    url = "mms://esd.jdibble.biz:8080/ESD/Dancing.mp3";
    mediaPlayer->playAudioFile(url);
}

void Client::blockOnPincode()
{
    setPincodeReceived(false);

    while (getPincodeReceived() == false)
    {
       QCoreApplication::processEvents();
    //   qDebug() << "Blocked";
    }
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

void Client::pincodeReceived(QString newPin)
{
    qDebug() << "pincode Received";
    pincode = newPin;
    setPincodeReceived(true);
}

bool Client::getPincodeReceived()
{
    QMutexLocker locker(&pincodeMutex);
  //  qDebug() << "get ";
    return pinReceived;
}

void Client::setPincodeReceived(bool newReceived)
{
    QMutexLocker locker(&pincodeMutex);
    qDebug() << "set " << newReceived;
    pinReceived = newReceived;
}

void Client::normalPlay()
{
    mediaPlayer->normal();
}

void Client::locationChanged(int exhibit)
{
    requestExhibit(exhibit);
}

void Client::exhibitNumberEntered()
{
    int exhibitNumber = exhibit.toInt();
    qDebug() << exhibitNumber;
    requestExhibit(exhibitNumber);
    exhibit.clear();
}

void Client::buttonPressed(KeypadButton button)
{
    bool exhibitAltered = false;

    if (!authenticated)
    {
        // we shouldnt do anything
        return;
    }

    switch (button)
    {
    case KeypadButton::KEY_1:
        exhibit.append("1");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_2:
        exhibit.append("2");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_3:
        exhibit.append("3");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_4:
        exhibit.append("4");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_5:
        exhibit.append("5");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_6:
        exhibit.append("6");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_7:
        exhibit.append("7");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_8:
        exhibit.append("8");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_9:
        exhibit.append("9");
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_0:
        if (!exhibit.isEmpty())
        {
            // only append 0 if its not the start
            exhibit.append("0");
        }
        exhibitAltered = true;
        break;
    case KeypadButton::KEY_A: // play/pause button
        mediaPlayer->playPauseHandle();
        break;
    case KeypadButton::KEY_B: // fast forward button
        mediaPlayer->fastForward();
        break;
    case KeypadButton::KEY_C: // rewind button
        mediaPlayer->rewind();
        break;
    case KeypadButton::KEY_D: // mute button
        mediaPlayer->muteHandle();
        break;
    case KeypadButton::KEY_E: // volume up button
        mediaPlayer->changeVolume(true);
        break;
    case KeypadButton::KEY_F: // volume down button
        mediaPlayer->changeVolume(false);
        break;
    default /*NONE*/:
        normalPlay();
    }

    if (exhibitAltered)
    {
        // reset timer as exhibit number was pressed
        buttonTimeout->start(3000);
    }
}

void Client::noKeypad()
{
    qCritical("No keypad, error set");
    error = true;
    setPincodeReceived(true);
}

void Client::forceQuit()
{
    qCritical("Exiting");
    QCoreApplication::quit();
    // qApp->quit();
}
