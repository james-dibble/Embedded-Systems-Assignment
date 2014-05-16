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
    QString deviceName = "PINTS";
    QString pin;
    QMutex netMutex;
    QString replyString;

signals:
    void forwardMessage(QString, unsigned int);
    void networkFinished();

public slots:
    void begin();
    void getRequest(QUrl, QString);

private slots:
    void replyReceived(QNetworkReply*);
};

#endif // NETWORK_H
