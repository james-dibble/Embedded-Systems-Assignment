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
    enum KeypadButton pincode[4] = { KEY_NONE, KEY_NONE, KEY_NONE, KEY_NONE };

    int lastCol = -1;
    bool pressed = false;
    enum segChar writeChar;

    if (setup() != 0)
    {
        emit keypadFinished();
        return;
    }

    // flash 7 segs a few times to show its ready
    selectCol(0xF);
    for (int i=0; i < 3; i++)
    {
        write7seg(SEG_EIGHT);
        usleep(10000);
        write7seg(SEG_BLANK);
        usleep(10000);
    }

    // main loop
    for (col = 0; col < 4; col++, col %= 4)
    {
        QCoreApplication::processEvents();

        write7seg(SEG_BLANK);
        selectCol(col);

        enum KeypadButton button = buttonPressed(col);

        if (button == KEY_NONE)
        {
            if (lastCol == col)
            {
                pressed = false;
            }

            // qDebug() << "nothing";
        }
        else
        {
            if (pressed)
            {
                // ignore button held down
                // qDebug() << "held\n";
            }
            else if (buttonIsNumeric(button))
            {
                // a new button was pressed
                if (needPincode)
                {
                    // add it to pincode
                    pincode[count] = button;
                    count++;
                    qDebug() << "Button is" << getRealNumber(button) << "count is " << count;
                }
                else
                {
                    // forward to main thread
                    qDebug() << "Button is" << getRealNumber(button);
                    emit forwardButton(button);
                }
                pressed = true;
                lastCol = col;
            }
        }

        if (count == 4)
        {
            QString pin = QString("%1%2%3%4").arg(getRealNumber(pincode[0]))
                                  .arg(getRealNumber(pincode[1]))
                                  .arg(getRealNumber(pincode[2]))
                                  .arg(getRealNumber(pincode[3]));
            if (needPincode)
            {
                emit forwardPincode(pin);
            }
            needPincode = false;
        }

        writeChar = getHexRepresentation(pincode[col]);
        write7seg(writeChar);

        usleep(1000);
    }

}

int KeypadController::setup()
{
    needPincode = false;
    col = 0;
    count = 0;

    fd = open(keypadname.toLocal8Bit().data(), O_RDWR); //Sets FD to open said port

    if (fd < 0) //If Statement produces error message if selected port cannot be opened
    {
        qDebug() << "error" << errno << " opening " << keypadname << strerror(errno);
        return 1;
    }

    set_interface_attribs(B115200, 0);  // set speed to 115,200 bps, 8n1 (no parity)
    set_blocking(0);

    // Set up Ports on PIO
    sendToKeypad("@00D000\r"); // Sets Port A to output
//    qDebug() << response;
    sendToKeypad("@00D1FF\r"); // Sets Port B to input
//    qDebug() << response;
    sendToKeypad("@00D200\r"); // Sets Port C to output
//    qDebug() << response;
    return 0;
}

void KeypadController::pinRequested()
{
    qDebug() << "pin requested";
    needPincode = true;
    count = 0;
}

int KeypadController::sendToKeypad(QString message)
{
    int ret = writeKeypad(message.toLocal8Bit().data());
    if (ret < 0)
    {
        return ret;
    }
    return read(fd, response, BUFMAX);
}

int KeypadController::writeKeypad(char* message)
{
    int nbytes = write(fd, message, strlen(message));
    if (nbytes < 0)
    {
        qWarning() << "Error while writing";
    }
    return nbytes;
}

int KeypadController::selectCol(int col)
{
    char colChar;
    char message[10];

    switch (col)
    {
    case 0:
        colChar = '1';
        break;
    case 1:
        colChar = '2';
        break;
    case 2:
        colChar = '4';
        break;
    case 3:
        colChar = '8';
        break;
    default:
        // all columns
        colChar = 'F';
    }

    if (colChar)
    {
        // construct message
        sprintf(message, "@00P00%c\r", colChar);
        sendToKeypad(message);
    }

    usleep(50);
    return 0;
}

int KeypadController::write7seg(enum segChar character)
{
    char message[10];
    // construct message
    sprintf(message, "@00P2%02x\r", character);
    sendToKeypad(message);
    // qDebug() << response;
    return 0;
}

enum KeypadButton KeypadController::buttonPressed(int col)
{
    enum KeypadButton button = KEY_NONE;

    sendToKeypad("@00P1?\r");

    if (response[0] != '!')
    {
        qWarning() << "Bad Response";
    }
    else if (strncmp(response,"!00F0", 5) != 0)
    {
        // something was pressed
        int row = getRowNumber(&response[4]);
        button = getButton(row, col);
    }
    // qDebug() << response;
 //   printf("message %c%c%c%c%c\n", buf[0],buf[1],buf[2],buf[3],buf[4]);
//	getchar();
    return button;
}

enum KeypadButton KeypadController::getButton(int row, int col)
{
    return static_cast<KeypadButton>(((row - 1) * 4) + (col + 1));
}

int KeypadController::getRowNumber(char* ch)
{
    int row = 0;
    long int buttonValueRead;

    buttonValueRead = strtol(ch, NULL, 16);
    if (buttonValueRead & 0x1)
    {
        row = 1;
    }
    else if (buttonValueRead & 0x2)
    {
        row = 2;
    }
    else if (buttonValueRead & 0x4)
    {
        row = 3;
    }
    else /*(buttonValueRead & 0x8)*/
    {
        row = 4;
    }
    return row;
}

enum segChar KeypadController::getHexRepresentation(enum KeypadButton button)
{
    enum segChar seg;
    switch (button)
    {
    case KEY_1:
        seg = SEG_ONE; break;
    case KEY_2:
        seg = SEG_TWO; break;
    case KEY_3:
        seg = SEG_THREE; break;
    case KEY_4:
        seg = SEG_FOUR; break;
    case KEY_5:
        seg = SEG_FIVE; break;
    case KEY_6:
        seg = SEG_SIX; break;
    case KEY_7:
        seg = SEG_SEVEN; break;
    case KEY_8:
        seg = SEG_EIGHT; break;
    case KEY_9:
        seg = SEG_NINE; break;
    case KEY_0:
        seg = SEG_ZERO; break;
    case KEY_A:
        seg = SEG_A; break;
    case KEY_B:
        seg = SEG_B; break;
    case KEY_C:
        seg = SEG_C; break;
    case KEY_D:
        seg = SEG_D; break;
    case KEY_E:
        seg = SEG_E; break;
    case KEY_F:
        seg = SEG_F; break;
    default: // KEY_NONE
        seg = SEG_BLANK;
    }
    return seg;
}

int KeypadController::buttonIsNumeric(enum KeypadButton button)
{
    int isNumeric;
    switch (button)
    {
    case KEY_NONE:
        isNumeric = -1; break;
    case KEY_A:
    case KEY_B:
    case KEY_C:
    case KEY_D:
    case KEY_E:
    case KEY_F:
        isNumeric = 0; break;
    default /*Numeric*/:
        isNumeric = 1; break;
    }
    return isNumeric;
}

int KeypadController::getRealNumber(enum KeypadButton button)
{
    int number;
    switch (button)
    {
    case KEY_1:
        number = 1; break;
    case KEY_2:
        number = 2; break;
    case KEY_3:
        number = 3; break;
    case KEY_4:
        number = 4; break;
    case KEY_5:
        number = 5; break;
    case KEY_6:
        number = 6; break;
    case KEY_7:
        number = 7; break;
    case KEY_8:
        number = 8; break;
    case KEY_9:
        number = 9; break;
    case KEY_0:
        number = 0; break;
    default /*Letter or blank*/:
        number = -1; break;
    }
    return number;
}

/** Start Stackoverflow code*/
int KeypadController::set_interface_attribs(int speed, int parity)
{
        struct termios tty;
        memset (&tty, 0, sizeof tty);
        if (tcgetattr (fd, &tty) != 0)
        {
                fprintf (stderr, "error %d from tcgetattr\n", errno);
                return -1;
        }

        cfsetospeed (&tty, speed);
        cfsetispeed (&tty, speed);

        tty.c_cflag = (tty.c_cflag & ~CSIZE) | CS8;     // 8-bit chars
        // disable IGNBRK for mismatched speed tests; otherwise receive break
        // as \000 chars
        tty.c_iflag &= ~IGNBRK;         // ignore break signal
        tty.c_lflag = 0;                // no signaling chars, no echo,
                                        // no canonical processing
        tty.c_oflag = 0;                // no remapping, no delays
        tty.c_cc[VMIN]  = 0;            // read doesn't block
        tty.c_cc[VTIME] = 5;            // 0.5 seconds read timeout

        tty.c_iflag &= ~(IXON | IXOFF | IXANY); // shut off xon/xoff ctrl

        tty.c_cflag |= (CLOCAL | CREAD);// ignore modem controls,
                                        // enable reading
        tty.c_cflag &= ~(PARENB | PARODD);      // shut off parity
        tty.c_cflag |= parity;
        tty.c_cflag &= ~CSTOPB;
        tty.c_cflag &= ~CRTSCTS;

        if (tcsetattr (fd, TCSANOW, &tty) != 0)
        {
                fprintf (stderr, "error %d from tcsetattr\n", errno);
                return -1;
        }
        return 0;
}

void KeypadController::set_blocking(int should_block)
{
        struct termios tty;
        memset (&tty, 0, sizeof tty);
        if (tcgetattr (fd, &tty) != 0)
        {
                fprintf (stderr, "error %d from tggetattr\n", errno);
                return;
        }

        tty.c_cc[VMIN]  = should_block ? 1 : 0;
        tty.c_cc[VTIME] = 5;            // 0.5 seconds read timeout

        if (tcsetattr (fd, TCSANOW, &tty) != 0)
                fprintf (stderr, "error %d setting term attributes\n", errno);
}
/** End Stackoverflow code*/
