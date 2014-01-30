#include <stdio.h>
#include "networkystuff.h"


int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    networkyStuff theNetwork;

    QByteArray replyData = theNetwork.getHttp();

    fprintf(stderr, "The data: %s", replyData.data());

    qDebug() << "Date:" << QDate::currentDate() << "\n" << replyData.data() << " PINTS";
//    QByteArray.data()

    return a.exec();
}
