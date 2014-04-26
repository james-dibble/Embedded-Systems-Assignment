#ifndef LOCATIONTRACKER_H
#define LOCATIONTRACKER_H

#include <QObject>
#include <QProcess>

#include "clientIncludes.h"

class LocationTracker : public QObject
{
    Q_OBJECT
public:
    explicit LocationTracker(QObject *parent = 0);
    ~LocationTracker();

protected:
    QString getAccessPointName();

private:
    int lastStrength;
    QTimer *timer;
    bool firstRun;
    
signals:
    void forwardNewLocation(QString);
    void trackerFinished();
    
public slots:
    void startTracking();
    
private slots:
    void scan();
};

#endif // LOCATIONTRACKER_H
