#ifndef KEYPADCONTROLLER_H
#define KEYPADCONTROLLER_H

#include <QObject>
#include <QVector>
#include <unistd.h>
#include <termios.h>
//#include <stdlib.h>
#include <fcntl.h>

#include "clientIncludes.h"

#define BUFMAX 100



// Hexadecimal value to display the character correctly
enum segChar
{
    SEG_BLANK=0x00, SEG_ZERO=0x3F, SEG_ONE=0x06, SEG_TWO=0x5B, SEG_THREE=0x4F,
    SEG_FOUR=0x66, SEG_FIVE=0x6D, SEG_SIX=0x7D, SEG_SEVEN=0x07, SEG_EIGHT=0x7F,
    SEG_NINE=0x6F, SEG_A=0x77, SEG_B=0x7C, SEG_C=0x39, SEG_D=0x5E, SEG_E=0x79, SEG_F=0x71
};

class KeypadController : public QObject
{
    Q_OBJECT
public:
    explicit KeypadController(QObject *parent = 0);
    ~KeypadController();

protected:
    int setup();
    int sendToKeypad(QString);
    int writeKeypad(char*);
    int write7seg(enum segChar);
    int selectCol(int);
    enum KeypadButton buttonPressed(int col);
    enum KeypadButton getButton(int row, int col);
    enum segChar getHexRepresentation(enum KeypadButton);
    int getRowNumber(char* ch);
    int buttonIsNumeric(enum KeypadButton);
    int getRealNumber(enum KeypadButton);

    int set_interface_attribs(int, int);
    void set_blocking(int);

private:
    int fd;
    QString keypadname = "/dev/ttyACM0";
    char response[BUFMAX];
//    KeypadButton lastPressed;
    QVector<KeypadButton> pincodeVector;
    bool needPincode;
    int col;
    int count;

signals:
    void forwardButton(KeypadButton);
    void forwardPincode(QString);
    void keypadFinished();

public slots:
    void start();
    void pinRequested();

private slots:
//    void readAndWrite();
};

#endif // KEYPADCONTROLLER_H
