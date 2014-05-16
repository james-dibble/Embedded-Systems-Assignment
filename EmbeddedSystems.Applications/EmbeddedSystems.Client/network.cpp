#include "network.h"

Network::Network(QObject *parent) :
    QObject(parent)
{
}

Network::~Network()
{
}

void Network::begin()
{
    pin = "0000";
    networkMan = new QNetworkAccessManager();

#if PROXY
    QNetworkProxy proxy;
     proxy.setType(QNetworkProxy::HttpProxy);
     proxy.setHostName("proxysg.uwe.ac.uk");
     proxy.setPort(8080);
  //   proxy.setUser("username");
   //  proxy.setPassword("password");
     QNetworkProxy::setApplicationProxy(proxy);
     networkMan->setProxy(proxy);
#endif

     QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), this, SLOT(replyReceived(QNetworkReply*)));

     // QThread::exec();
}

void Network::getRequest(QUrl url, QString newPin /* = -1*/ )
{
    // update pin if supplied with one
    if (!newPin.isEmpty())
    {
        pin = newPin;
    }

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

 //   qDebug() << "\nIt should be: MTIzOjEyMzQ=";
    qDebug() << "data base64: " << data.toBase64();

    QString headerData = "Basic " + data.toBase64();
 //   QString headerData = (QString) "Basic " + "MTIzOjEyMzQ=";

    request.setRawHeader("Authorization", headerData.toLocal8Bit());

    QList<QByteArray> list = request.rawHeaderList();
    qDebug() << list;

    networkMan->get(request);

    qDebug() << "get sent to" << url;
}

QUrl Network::getTrackLocation()
{
    QUrl url("ik0097@my.bristol.ac.uk");

    return url;
}

void Network::replyReceived(QNetworkReply* reply)
{
    QByteArray replyData;
    unsigned int httpStatusCode;
    qDebug() << "reply received";
    httpStatusCode = reply->attribute(QNetworkRequest::HttpStatusCodeAttribute).toUInt();
    qDebug() << "Qt NetworkCode Error" << reply->error();
    qDebug() << "Actual HTTP response" << httpStatusCode;

    if (reply->error() == QNetworkReply::NoError)
    {
            replyData = reply->readAll();
            replyString = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << replyString;
    }
    else
    {
            qDebug() << "Error";
    }

    qDebug() << "forwarding message";
    emit forwardMessage(replyString, httpStatusCode);
}
