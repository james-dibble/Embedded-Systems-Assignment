#ifndef KEYPADCONTROLLER_H
#define KEYPADCONTROLLER_H

#include <QObject>
#include <QVector>

#include "clientIncludes.h"

class KeypadController : public QObject
{
    Q_OBJECT
public:
    explicit KeypadController(QObject *parent = 0);
    ~KeypadController();

//    int getPin();

protected:
    void read();
    void write();
    void selectCol(int);

private:
//    KeypadButton lastPressed;
    QVector<KeypadButton> pincodeVector;
    bool newPincode;
    QTimer *timer;
    int col;

signals:
    void forwardButton(KeypadButton);
    void keypadFinished();

public slots:
    void start();
    void pinRequested(QString&);

private slots:
    void readAndWrite();
};

#endif // KEYPADCONTROLLER_H
