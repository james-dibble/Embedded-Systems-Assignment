#include "lcdcontroller.h"

LcdController::LcdController(QObject *parent) :
    QObject(parent)
{
}

LcdController::~LcdController()
{
}

/*
 * Called on device start
 */
void LcdController::setup()
{
    // Setup LCD
    // Setup brightness
}

/*
 * Set the required state of the LCD
 * States:
 *  - Enter pin
 *  - Enter exhibit code
 *  - Playing
 */
void LcdController::setState()
{

}

/*
 * Writes out to the screen
 */
void LcdController::writeToScreen()
{

}

/*
 * Called during setup. Currently with hardcoded value.
 */
void LcdController::setBrightness(int brightness)
{

}
