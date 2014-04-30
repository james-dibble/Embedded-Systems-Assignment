#include "keypadcontroller.h"

KeypadController::KeypadController(QObject *parent) :
    QObject(parent)
{
}

KeypadController::~KeypadController()
{
}

void KeypadController::start()
{
    // read and write keypad on timer
    timer = new QTimer(this);
    connect(timer,SIGNAL(timeout()),this,SLOT(readAndWrite()));
    timer->start(1);

    newPincode = false;
    col = 0;
}

void KeypadController::pinRequested(QString& newPin)
{
 //   int newPin = 0;
 //   int pinDigit;

    newPincode = true;
    while (pincodeVector.size() < 4)
    {
       QCoreApplication::processEvents();
    }
    newPincode = false;

    for (int i = 0; i < pincodeVector.size(); i++)
    {
        newPin.append("1");
//        pinDigit = 1;

//        // shift pin to the left then add new digit
//        newPin *= 10;
//        newPin += pinDigit;
        qDebug() << newPin;
    }
#if DEBUG
    // force pincode
    newPin = "4041";
#endif
}

void KeypadController::readAndWrite()
{
    col++;
    selectCol(col);
    read();
    write();
//    qDebug() << "Read and write " << col;
}

void KeypadController::read()
{
    KeypadButton button;
    bool pressed = false;
    // read 4 rows looking for keypress
# if DEBUG
    pressed = true;
#endif
    if (pressed)
    {
        // handle button press
        button = KeypadButton::KEY_1;

        // if (button is number)
        //{
            if (newPincode)
            {
                pincodeVector.push_back(button);
            }
        //}
    }
}

void KeypadController::write()
{
    // write number for that 7 seg
    if (pincodeVector.size() > col)
    {
        // we have something to write
    }
}

void KeypadController::selectCol(int col)
{
    // send message to select column of keypad
    if (col == 0)
    {

    }
    else if (col == 1)
    {

    }
    else if (col == 2)
    {

    }
    else // col == 3
    {

    }

//	usleep(1000);
}
