#include "lcdcontroller.h"

LcdController::LcdController(QObject *parent) :
    QObject(parent)
{
}

LcdController::~LcdController()
{
    serial->close();
    delete serial;
}

/*
 * Called on device start
 */
void LcdController::setup()
{
    // Setup LCD
    serial = new QSerialPort(this);
    serial->setPortName(portName);

    status = serial->open(QIODevice::WriteOnly);

    if(status)
    {
        serial->setBaudRate(QSerialPort::Baud9600,QSerialPort::AllDirections);
        serial->setDataBits(QSerialPort::Data8);
        serial->setStopBits(QSerialPort::OneStop);
        serial->setFlowControl(QSerialPort::NoFLowControl);
        serial->setParity(QSerialPort::NoParity);

        // Set 16 Characters Wide
        serial->putChar(LCD_COMMAND);
        serial->putChar(4);

        // Set 2 Lines
        serial->putChar(LCD_COMMAND);
        serial->putChar(6);

        clearScreen();
    }

    // Setup brightness
    setBrightness(30);
}

/*
 * Set the required state of the LCD
 * States:
 *  - Enter pin
 *  - Enter exhibit code
 *  - Playing
 */
void LcdController::setState(stateType state)
{
    LCDState = state;

    switch(LCDState)
    {
    case Pin: writeEnterPin();
        break;
    case Loading: writeLoading();
        break;
    case Playing: writePlaying();
        break;
    }
}

void LcdController::writeEnterPin()
{
    clearScreen();
    writeToScreen("Enter pin...", LCDPosition.TOP, 0);
}

void LcdController::writeLoading()
{
    clearScreen();
    writeToScreen("Loading...", LCDPosition.TOP, 0);
}

void LcdController::writePlaying()
{
    clearScreen();
    writeToScreen("Exhibit Name", LCDPosition.TOP, 0);
    writeToScreen("00:00/00:00", LCDPosition.BOTTOM, 0);
}

void LcdController::setupPlayingTime(QString totalTime)
{
    if(LCDState == Playing)
    {
        writeToScreen(totalTime, LCDPosition.BOTTOM, 6);
    }

}

void LcdController::updatePlayingTime(QString time)
{
    if(LCDState == Playing)
    {
        writeToScreen(time, LCDPosition.BOTTOM, 0);
    }
}

/*
 * Writes out to the screen
 */
void LcdController::writeToScreen(QString data, LCDPosition position, int offset)
{
    //Check data size
    QString buff;

    // If data size is too big for the row - chop to size
    // This ensures that wrapping does not occur.
    if ((data.size()-1) > (17 - offset))
    {
        buff = data.remove(1,(17-offset));
    }
    else
    {
        buff = data;
    }

    // Move cursor to position.
    serial->putChar(LCD_DISPLAY_COMMAND);
    if(position == BOTTOM)
    {
        serial->putChar(LCD_BOTTOM_START + offset);
    }
    else
    {
        serial->putChar(LCD_TOP_START + offset);
    }

    // Write out each character in string.
    for (int i = 0; i <= buff.size(); i++)
    {
        serial->putChar(buff[i]);
    }
}

/*
 * Called during setup. Currently with hardcoded value.
 * Value between 1 - 30
 * Off 1
 * Min 2
 * Max 30
 */
void LcdController::setBrightness(int brightness)
{
    if(brightness > 30)
    {
        brightness = 30;
    }
    else if(brightness < 1)
    {
        brightness = 1;
    }

    if(status)
    {
        // Control character
        serial->putChar(LCD_COMMAND);

        // Brightness offset 128 - 157
        serial->putChar(127+brightness);
    }

}

void LcdController::clearScreen()
{
    // Clear Screen
    serial->putChar(LCD_DISPLAY_COMMAND);
    serial->putChar(0x01);

    // Move cursor to the start
    serial->putChar(LCD_DISPLAY_COMMAND);
    serial->putChar(128);
}
