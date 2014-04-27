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
    lastStrength = 0;
    firstRun = true;

    timer = new QTimer(this);
    connect(timer,SIGNAL(timeout()),this,SLOT(scan()));
    timer->start(5000);
}

void LocationTracker::scan()
{
    QProcess trackProc;
    QString processName = "iwlist wlan0 scan";
    // QString processName("ifconfig");
    int ourAccessPointNumber = -1;

    QString ourAccessPointName = getAccessPointName();

    if (ourAccessPointName.isEmpty())
    {
        return;
    }

    trackProc.start(processName);
    trackProc.waitForFinished();

    QString output = trackProc.readAllStandardOutput();

    if (trackProc.exitStatus() != 0)
    {
        qDebug() << trackProc.readAllStandardError();
        return;
    }

    qDebug() << output;
    QStringList lines = output.split("\n");
    QStringList ssids = lines.filter("ESSID:");

    if (ssids.isEmpty())
    {
        // found no access points
        qWarning() << "No access points found, you may be offline!";
        return;
    }
    for (int i=0; i < ssids.size(); i++)
    {
        QString ssid = ssids.at(i);
        if (ssid.indexOf(ourAccessPointName) >= 0)
        {
            qDebug() << "Found our access point";
            ourAccessPointNumber = i;
        }
    }

    if (ourAccessPointNumber != -1)
    {
        QStringList signalStengths = lines.filter("Quality=");
        QString strengthLine = signalStengths.at(ourAccessPointNumber);
        qDebug() << strengthLine;

        int start = strengthLine.indexOf("=");
        // make start next char after '='
        start++;
        int end = strengthLine.indexOf(" ", start);
        int length = end - start;
        QString strengthFraction = strengthLine.mid(start, length);
        qDebug() << strengthFraction;

        int mid = strengthFraction.indexOf("/");
        int numerator = strengthFraction.left(mid).toInt();
        int denominator = strengthFraction.right(mid).toInt();
        double thisStrength = numerator;
        qDebug() << thisStrength;

        if (thisStrength != lastStrength && !firstRun)
        {
            qDebug() << "Strength changed";
        }
        firstRun = false;
        lastStrength = thisStrength;
    }
}

QString LocationTracker::getAccessPointName()
{
    QString accessPoint = "";
    QProcess iwconfigProc;
    QString processName = "iwconfig wlan0";
    iwconfigProc.start(processName);
    iwconfigProc.waitForStarted();
    iwconfigProc.waitForFinished();
    QString output = iwconfigProc.readAllStandardOutput();
    qDebug() << output;

    QStringList ssids = output.split("\n").filter("ESSID:");
    if (ssids.isEmpty())
    {
        // found no access points
        qWarning() << "Not connected!";
    }
    else
    {
        QString ssidLine = ssids.at(0);
        int start = ssidLine.indexOf("\"");
        // make start next char after '"'
        start++;
        int end = ssidLine.indexOf("\"", start);
        int length = end - start;
        accessPoint = ssidLine.mid(start, length);
    }
    qDebug() << accessPoint;
    return accessPoint;
}
