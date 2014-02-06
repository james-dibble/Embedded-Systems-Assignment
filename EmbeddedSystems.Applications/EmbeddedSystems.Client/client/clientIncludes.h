#ifndef CLIENTINCLUDES_H
#define CLIENTINCLUDES_H

#include <QObject>
#include <QString>
#include <QDebug>
#include <QUrl>
#include <QtNetwork/QNetworkRequest>
#include <QtNetwork/QNetworkReply>
//#include <QtNetwork>
//#include <QtNetwork/qnetworkaccessmanager.h>
#include <QNetworkProxy>

#define DEBUG 1

enum class Exhibit{EXHIBIT_1, EXHIBIT_2, EXHIBIT_3};

const QString baseUrl = "http://esd.jdibble.biz/";


#endif // CLIENTINCLUDES_H


// const QString qstr = "http://esd.jdibble.biz/";
/*
 *http://handset.api.esd.jdibble.biz/
 *
 *api/handset/authenticate
 */
