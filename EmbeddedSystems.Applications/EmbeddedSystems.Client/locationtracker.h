#ifndef LOCATIONTRACKER_H
#define LOCATIONTRACKER_H

#include <QObject>
#include <QProcess>

#include "clientIncludes.h"

#define EXHIBIT_A 1
#define EXHIBIT_B 2

class LocationTracker : public QObject
{
    Q_OBJECT
public:
    explicit LocationTracker(QObject *parent = 0);
    ~LocationTracker();

protected:
    void scanWireless();
    int getSignalQuality();

private:
    int strengthThreshold;
    int lastExhibit;
    QTimer *timer;
    
signals:
    void forwardNewLocation(int);
    void trackerFinished();
    
public slots:
    void startTracking();
    
private slots:
    void scan();
};

#endif // LOCATIONTRACKER_H
