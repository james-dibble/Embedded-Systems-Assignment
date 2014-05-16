#ifndef CLIENTINCLUDES_H
#define CLIENTINCLUDES_H

#include <QObject>
#include <QString>
#include <QDebug>
#include <QUrl>
#include <QtNetwork/QNetworkRequest>
#include <QtNetwork/QNetworkReply>
#include <QNetworkProxy>
// #include <QtTest/QTest>
#include <QtCore>
#include <QTimer>

#define DEBUG 1

#define PROXY 1

enum class Exhibit{EXHIBIT_1, EXHIBIT_2, EXHIBIT_3};

enum class KeypadButton{KEY_NONE,
                        KEY_1, KEY_2, KEY_3, KEY_F,
                        KEY_4, KEY_5, KEY_6, KEY_E,
                        KEY_7, KEY_8, KEY_9, KEY_D,
                        KEY_A, KEY_0, KEY_B, KEY_C};

const QString baseUrl = "http://esd.jdibble.biz/";
const QString handsetApiUrl = "http://handset.api.esd.jdibble.biz/api/handset/authenticate";
// const QString handsetApiUrl = "http://esd.jdibble.biz:8080/ESD/levels.mp3";
const QString adminUrl = "admin.console.esd.jdibble.biz/";
const QString pintsUrl = "http://handset.api.esd.jdibble.biz/file/1";
#endif // CLIENTINCLUDES_H
