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
//    request.setHeader( QNetworkRequest::ContentTypeHeader, "some/type" );

    request.setRawHeader("User-Agent", "PINTS");



    QString concatenated = deviceName + ":" + pin;
 //   QByteArray data = concatenated.toLocal8Bit().toBase64();
    QByteArray data ;
    data.append( concatenated);
    data.toBase64();
    qDebug() << data.toBase64();
  //  QString::
  //  QString headerData = "Basic " + data.toBase64();
    QString headerData = (QString) "Basic " + "MTIzOjEyMzQ=";
  //  request.setRawHeader("Authorization", headerData.toLocal8Bit());
    request.setRawHeader("Authorization", headerData.toUtf8());

    qDebug() << headerData;

    QList<QByteArray> list = request.rawHeaderList();
    qDebug() << list;

    for (int i=0; i < list.count();i++)
    {
        qDebug() << list.at(i).data();
    }

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

    if (reply->error() == QNetworkReply::NoError)
    {
            replyData = reply->readAll();
            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
    }
    else
    {
      //  qDebug() << "the HTTP Status Code" <
            qDebug() << "the error" << reply->error();
            replyData = reply->readAll();


            QVariant statusCode = reply->attribute( QNetworkRequest::HttpStatusCodeAttribute );
                if ( !statusCode.isValid() )
                    return replyData;

                int status = statusCode.toInt();

                if ( status != 200 )
                {
                    QString reason = reply->attribute( QNetworkRequest::HttpReasonPhraseAttribute ).toString();
                    qDebug() << reason;
                }




            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
    }

    return replyData;
}
