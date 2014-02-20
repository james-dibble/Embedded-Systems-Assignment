#ifndef CLIENT_H
#define CLIENT_H

#include "unistd.h"
#include <ctime>
#include <cerrno>

#include "clientIncludes.h"
#include "network.h"

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

private:
    Network* network;
    QString reply;
    bool authenticated;
    QMutex clientMutex;
    bool waitOver;

signals:
    void request(QUrl);

public slots:
    void networkReply(QString);

};

#endif // CLIENT_H

// colon base 64
