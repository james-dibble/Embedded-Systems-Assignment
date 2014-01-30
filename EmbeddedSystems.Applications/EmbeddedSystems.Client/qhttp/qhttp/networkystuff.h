#ifndef NETWORKYSTUFF_H
#define NETWORKYSTUFF_H

#include <QObject>

class networkyStuff : public QObject
{
    Q_OBJECT
public:
    explicit networkyStuff(QObject *parent = 0);
    ~networkyStuff();
    
signals:
    
public slots:
    
};

#endif // NETWORKYSTUFF_H
