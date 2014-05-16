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
    lastExhibit = EXHIBIT_A;
    timer = new QTimer(this);
    connect(timer,SIGNAL(timeout()),this,SLOT(scan()));
    timer->start(5000);
}

void LocationTracker::scan()
{
    int exhibit, quality;

    // force wireless rescan
    scanWireless();

    quality = getSignalQuality();

    if (quality > strengthThreshold)
    {
        qDebug() << "Exhibit A";
        exhibit = EXHIBIT_A;
    }
    else
    {
        qDebug() << "Exhibit B";
        exhibit = EXHIBIT_B;
    }

    if (exhibit != lastExhibit)
    {
        emit forwardNewLocation(exhibit);
        lastExhibit = exhibit;
    }
}

void LocationTracker::scanWireless()
{
    QProcess scanProc;
    QString processName = "iwlist wlan0 scan";

    scanProc.start(processName);
    scanProc.waitForFinished();

    if (scanProc.exitStatus() != 0)
    {
        qDebug() << scanProc.readAllStandardError();
    }
}

int LocationTracker::getSignalQuality()
{
    QString quality = "";
    QProcess iwconfigProc;
    QString processName = "iwconfig wlan0";
    iwconfigProc.start(processName);
    iwconfigProc.waitForStarted();
    iwconfigProc.waitForFinished();
    QString output = iwconfigProc.readAllStandardOutput();
    // qDebug() << output;

    QStringList qualities = output.split("\n").filter("Quality");
    if (qualities.isEmpty())
    {
        // found no access points
        qWarning() << "No quality!";
    }
    else
    {
        //           Link Quality=49/70  Signal level=-61 dBm
        QString qualityLine = qualities.at(0);
        int start = qualityLine.indexOf("=");
        // make start next char after '"'
        start++;
        int end = qualityLine.indexOf("/", start);
        int length = end - start;
        quality = qualityLine.mid(start, length);
    }
    qDebug() << quality;
    return quality.toInt();
}
