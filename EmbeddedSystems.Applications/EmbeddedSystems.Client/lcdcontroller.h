#ifndef LCDCONTROLLER_H
#define LCDCONTROLLER_H

#include <QObject>
#include <QSerialPort>

#include "clientIncludes.h"

#define LCD_COMMAND 0x7C
#define LCD_DISPLAY_COMMAND 0xFE
#define LCD_TOP_START 0x80
#define LCD_BOTTOM_START 0xC0

enum stateType {
    Pin,
    Loading,
    Playing
} LCDState;

enum LCDPosition {
    TOP,
    BOTTOM
};

class LcdController : public QObject
{
    Q_OBJECT
public:
    explicit LcdController(QObject *parent = 0);
    ~LcdController();
    void setup();
    void setState();
    void setupPlayingTime(QString totalTime);
    void updatePlayingTime(QString time);

private:
    QSerialPort *serial;
    QString portName = "ttyO2";
    bool status = false;
    void writeToScreen(QString data, LCDPosition position, int offset);
    void writeEnterPin();
    void writeLoading();
    void writePlaying();
    void clearScreen();

protected:
    void setBrightness(int brightness);
};

#endif // LCDCONTROLLER_H
