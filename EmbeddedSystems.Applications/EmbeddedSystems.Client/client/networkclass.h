#ifndef NETWORKCLASS_H
#define NETWORKCLASS_H

#include "clientIncludes.h"

class NetworkClass : public QObject
{
    Q_OBJECT
public:
    explicit NetworkClass(QObject *parent = 0);
    ~NetworkClass();
    QByteArray getRequest(QUrl);
    QUrl getTrackLocation();

private:
    QNetworkAccessManager* networkMan;

signals:

public slots:

private slots:
    QByteArray replyReceived(QNetworkReply*);
};

#endif // NETWORKCLASS_H
