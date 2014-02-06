#ifndef NETWORK_H
#define NETWORK_H

#include "clientIncludes.h"

class Network : public QObject
{
    Q_OBJECT
public:
    explicit Network(QObject *parent = 0);
    ~Network();
    QByteArray getRequest(QUrl);
    QUrl getTrackLocation();

private:
    QNetworkAccessManager* networkMan;
    int deviceName = 123;
    int pin = 1234;

signals:

public slots:

private slots:
    QByteArray replyReceived(QNetworkReply*);
};

#endif // NETWORK_H
