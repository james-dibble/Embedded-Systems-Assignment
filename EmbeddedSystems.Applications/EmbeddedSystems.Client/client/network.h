#ifndef NETWORK_H
#define NETWORK_H

#include "clientIncludes.h"

class Network : public QObject
{
    Q_OBJECT
public:
    explicit Network(QObject *parent = 0);
    ~Network();
    QUrl getTrackLocation();

private:
    QNetworkAccessManager* networkMan;
    int deviceName = 123;
    int pin = 3196;
    QMutex netMutex;
    QString replyString;

signals:
    void forwardMessage(QString);
    void networkFinished();

public slots:
    void begin();
    QString getRequest(QUrl);

private slots:
    void replyReceived(QNetworkReply*);
};

#endif // NETWORK_H
