#ifndef NETWORKYSTUFF_H
#define NETWORKYSTUFF_H

#include <QObject>
#include <QtNetwork/QHttp>
#include <QtNetwork/qnetworkaccessmanager.h>
#include <QtNetwork/QNetworkRequest>
#include <QtNetwork/QNetworkReply>
#include <QUrl>
#include <QNetworkProxy>

#include <QCoreApplication>
#include <QDebug>
#include <QDate>

#include <QThread>

class networkyStuff : public QObject
{
    Q_OBJECT
public:
    explicit networkyStuff(QObject *parent = 0);
    ~networkyStuff();
    QByteArray getHttp();

private:
    QNetworkAccessManager* networkMan;
    QNetworkAccessManager netMan;
//    networkyStuff* checkFinished = new networkyStuff;
    QEventLoop* eventLoop;

 //   QNetworkRequest* request;
  //  QNetworkReply* reply;
    
signals:
    
public slots:

private slots:
    QByteArray itsFinished(QNetworkReply*);
    
};

#endif // NETWORKYSTUFF_H
