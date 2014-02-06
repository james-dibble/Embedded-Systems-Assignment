#include "network.h"

Network::Network(QObject *parent) :
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

Network::~Network()
{
}

QByteArray Network::getRequest(QUrl url)
{
    QByteArray response;

    QNetworkRequest request(url);
    request.setUrl(url);

    request.setRawHeader("User-Agent", "PINTS");

    qDebug() << deviceName << pin;

 //   QString concatenated = QString("%1:%2").arg(deviceName,pin);
    QString namePinKey;
    namePinKey = QString("%1:%2").arg(deviceName).arg(pin);
    qDebug() << "namePinKey: " << namePinKey;

 //   QByteArray data = concatenated.toLocal8Bit().toBase64();
    QByteArray data ;
    data.append(namePinKey);

    qDebug() << "\nIt should be: MTIzOjEyMzQ=\n";
    qDebug() << "data base64: " << data.toBase64();

    QString headerData = "Basic " + data.toBase64();
 //   QString headerData = (QString) "Basic " + "MTIzOjEyMzQ=";

    request.setRawHeader("Authorization", headerData.toLocal8Bit());

    QList<QByteArray> list = request.rawHeaderList();
    qDebug() << list;

    networkMan->get(request);

    qDebug() << url << " & " << url.toString();

    return response;
}

QUrl Network::getTrackLocation()
{
    QUrl url;

    return url;
}

QByteArray Network::replyReceived(QNetworkReply* reply)
{
    QByteArray replyData;
    qDebug() << "reply received";
    qDebug() << "Qt NetworkCode Error" << reply->error();
    qDebug() << "Actual HTTP response" << reply->attribute(QNetworkRequest::HttpStatusCodeAttribute).toUInt();

    if (reply->error() == QNetworkReply::NoError)
    {
            replyData = reply->readAll();
            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
    }
    else
    {

    //    qDebug() << "the error" << reply->attribute();
            replyData = reply->readAll();

            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
    }

    return replyData;
}
