#include "networkystuff.h"

networkyStuff::networkyStuff(QObject *parent) :
    QObject(parent)
{
}

networkyStuff::~networkyStuff(){}

QByteArray networkyStuff::getHttp()
{
    const QString qstr = "http://esd.jdibble.biz/";
  //  const QString qstr = "mms://esd.jdibble.biz/ESD/Dancing.mp3";
  //  const QString qstr = "http://www.google.co.uk";
    const QUrl url = qstr;

    networkMan = new QNetworkAccessManager();
 //   eventLoop = new QEventLoop();
    QNetworkRequest request(url);
    request.setHeader( QNetworkRequest::ContentTypeHeader, "some/type" );
    request.setRawHeader("Last-Modified", "Sun, 06 Nov 1994 08:49:37 GMT");





    QNetworkProxy proxy;
     proxy.setType(QNetworkProxy::HttpProxy);
     proxy.setHostName("proxysg.uwe.ac.uk");
     proxy.setPort(8080);
  //   proxy.setUser("username");
   //  proxy.setPassword("password");
     QNetworkProxy::setApplicationProxy(proxy);


    networkMan->setProxy(proxy);


  //  QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), )


 //   QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), eventLoop, SLOT(quit()));

    QObject::connect(networkMan, SIGNAL(finished(QNetworkReply*)), this, SLOT(itsFinished(QNetworkReply*)));

  //  url.user
    QByteArray rep;
  //  networkMan->get(QNetworkRequest(url));
    networkMan->get(request);

    qDebug() << url << " & " << url.toString();

//    reply = networkMan->get(*request);


//    eventLoop->exec(QEventLoop::ExcludeUserInputEvents);

//    if (reply->error() != QNetworkReply::NoError)
//    {
//        qDebug() << "err " << reply->error();
//    }
//    else
//    {
//        qDebug() << "no err";
//    }


//    QByteArray replyData = reply->readAll();

//    qDebug() << reply->header(QNetworkRequest::ContentTypeHeader);



    return rep;

}

QByteArray networkyStuff::itsFinished(QNetworkReply* theReply)
{
    QByteArray replyData;
    qDebug() << "sup";

    if (theReply->error() == QNetworkReply::NoError) {
            replyData = theReply->readAll();
            QString str = QString::fromUtf8(replyData.data(), replyData.size());
            qDebug() << "the reply " << str;
        } else {
            qDebug() << "the error" << theReply->error();
        }



    return replyData;

}
//QNetworkAccessManager* networkMan = new QNetworkAccessManager();


//networkMan->get(QNetworkRequest(QUrl("esd.jdibble.biz/ESD/api/file/1")));
