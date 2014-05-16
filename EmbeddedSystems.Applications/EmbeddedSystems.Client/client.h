#ifndef CLIENT_H
#define CLIENT_H

#include <ctime>
#include <cerrno>

#include "clientIncludes.h"
#include "network.h"
#include "keypadcontroller.h"
// #include "lcdcontroller.h"
#include "locationtracker.h"
#include "mediaplayer.h"

#include <json/json.h>

class Client : public QObject
{
    Q_OBJECT
public:
    explicit Client(QObject *parent = 0);
    ~Client();

    void startClient();
    bool authenticateDevice();

protected:
    void blockOnReply();
    void blockOnPincode();
    bool parseResponse();
    bool getWaitOver();
    void setWaitOver(bool);
    bool getPincodeReceived();
    void setPincodeReceived(bool);

    void requestExhibit(int);
    void normalPlay();
    void playPause();
    void fastForward();
    void rewind();

private:
    Network* network;
    KeypadController* keypad;
    LocationTracker* tracker;
//    LcdController* lcd;
    MediaPlayer* mediaPlayer;
    QString reply;
    int httpCode;
    bool authenticated;
    QMutex clientMutex;
    bool waitOver;
    QString file;
    bool pinReceived;
    QMutex pincodeMutex;
    QString pincode;

signals:
    void request(QUrl, QString = "");
    void getPin();

public slots:
    void networkReply(QString, unsigned int);
    void buttonPressed(KeypadButton);
    void pincodeReceived(QString);
    void locationChanged(int);
};

#endif // CLIENT_H

// colon base 64
