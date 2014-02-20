#include "locationtracker.h"

LocationTracker::LocationTracker(QObject *parent) :
    QObject(parent)
{
}

LocationTracker::~LocationTracker()
{
}

void LocationTracker::startTracking()
{
    QProcess trackProc;
  //  QString processName("iwlist wlan0 scan");
    QString processName("ifconfig");
    trackProc.start(processName);
    trackProc.waitForFinished();

    if (trackProc.exitStatus() != 0)
    {
        QString err(trackProc.readAllStandardError());
        qDebug() << this << ": \n" << err;
    }
    else
    {
        QString output(trackProc.readAllStandardOutput());
        qDebug() << this << ": \n" << output;
    }

}
