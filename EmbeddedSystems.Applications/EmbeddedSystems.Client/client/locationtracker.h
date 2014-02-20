#ifndef LOCATIONTRACKER_H
#define LOCATIONTRACKER_H

#include <QObject>
#include <QProcess>
#include <QString>
#include <QDebug>

class LocationTracker : public QObject
{
    Q_OBJECT
public:
    explicit LocationTracker(QObject *parent = 0);
    ~LocationTracker();
    void startTracking();
    
signals:
    
public slots:
    
};

#endif // LOCATIONTRACKER_H
