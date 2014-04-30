#ifndef CLIENT_H
#define CLIENT_H

#include "unistd.h"
#include <ctime>
#include <cerrno>

#include "clientIncludes.h"
#include "network.h"
#include "keypadcontroller.h"
#include "locationtracker.h"

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
    bool parseResponse();
    bool getWaitOver();
    void setWaitOver(bool);

    void requestExhibit(int);
    void playPause();
    void fastForward();
    void rewind();

private:
    Network* network;
    KeypadController* keypad;
    LocationTracker* tracker;
    QString reply;
    int httpCode;
    bool authenticated;
    QMutex clientMutex;
    bool waitOver;

signals:
    void request(QUrl, QString = "");
    void getPin(QString&);

public slots:
    void networkReply(QString, unsigned int);
    void buttonPressed(KeypadButton);
    void locationChanged(QString);
};

#endif // CLIENT_H

// colon base 64
