#include "networkclass.h"

NetworkClass::NetworkClass(QObject *parent) :
    QObject(parent)
//{
//}
//NetworkClass::NetworkClass()
{
    networkMan = new QNetworkAccessManager();

    QNetworkProxy proxy;
     proxy.setType(QNetworkProxy::HttpProxy);
     proxy.setHostName("proxysg.uwe.ac.uk");
     proxy.setPort(8080);
  //   proxy.setUser("username");
   //  proxy.setPassword("password");
     QNetworkProxy::setApplicationProxy(proxy);
     networkMan->setProxy(proxy);


     QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), this, SLOT(replyReceived(QNetworkReply*)));
}

NetworkClass::~NetworkClass()
{
}

QByteArray NetworkClass::getRequest(QUrl url)
{
    QByteArray response;

    QNetworkRequest request(url);

    request.setUrl(url);
//    request.setHeader( QNetworkRequest::ContentTypeHeader, "some/type" );

    request.setRawHeader("User-Agent", "PINTS");

    networkMan->get(request);

    qDebug() << url << " & " << url.toString();

    return response;
}

QUrl NetworkClass::getTrackLocation()
{
    QUrl url;

    return url;
}

QByteArray NetworkClass::replyReceived(QNetworkReply* reply)
{
    QByteArray replyData;
    qDebug() << "reply received";

    if (reply->error() == QNetworkReply::NoError) {
            replyData = reply->readAll();
            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
        } else {
            qDebug() << "the error" << reply->error();
        }



    return replyData;
}
