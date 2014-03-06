#ifndef LCDCONTROLLER_H
#define LCDCONTROLLER_H

#include <QObject>

#include "clientIncludes.h"

class LcdController : public QObject
{
    Q_OBJECT
public:
    explicit LcdController(QObject *parent = 0);
    ~LcdController();
    void setup();
    void setState();

protected:
    void writeToScreen();
    void setBrightness(int brightness);
};

#endif // LCDCONTROLLER_H
