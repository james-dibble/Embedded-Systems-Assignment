#include "client.h"

#include <QCoreApplication>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    Client client;
    client.startClient();

    return a.exec();
}
