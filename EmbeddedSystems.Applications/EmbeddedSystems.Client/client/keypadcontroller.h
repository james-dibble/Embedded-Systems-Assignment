#ifndef KEYPADCONTROLLER_H
#define KEYPADCONTROLLER_H

#include <QObject>

#include "clientIncludes.h"

class KeypadController : public QObject
{
    Q_OBJECT
public:
    explicit KeypadController(QObject *parent = 0);
    ~KeypadController();
    void start();

protected:
    void setup();
    void read();
    void write();
    
signals:
    void keyPressed(KeypadButton);
    
public slots:
    
};

#endif // KEYPADCONTROLLER_H
