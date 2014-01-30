#include <QCoreApplication>
#include <QtNetwork/QHttp>
#include <QtNetwork/qnetworkaccessmanager.h>
#include <QtNetwork/QNetworkRequest>
#include <QtNetwork/QNetworkReply>
#include <QUrl>

// #include "networkystuff.h"


int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    const QUrl url = (QString) "esd.jdibble.biz/ESD/api/file/1";

    QNetworkAccessManager* networkMan = new QNetworkAccessManager();
//    networkyStuff* checkFinished = new networkyStuff;
    QEventLoop *eventLoop = new QEventLoop();

    QNetworkRequest* request = new QNetworkRequest(url);
    QNetworkReply* reply;

  //  QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), )


    QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)),
                     eventLoop, SLOT(quit()));


 //   networkMan->get(QNetworkRequest(QUrl("esd.jdibble.biz/ESD/api/file/1")));
    reply = networkMan->get(*request);

    eventLoop->exec(QEventLoop::ExcludeUserInputEvents);


    QByteArray replyData = reply->readAll();

    return a.exec();
}
