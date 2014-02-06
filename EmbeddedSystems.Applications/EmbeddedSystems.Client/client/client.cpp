#include "client.h"

extern const QString baseUrl;

Client::Client()
{
}

Client::~Client()
{
}

void Client::startClient()
{
    bool authenticated = false;

    // we need to authenticate the keypad before we can do anything
    while (!authenticated)
    {
        authenticated = authenticateDevice();
    }

    qDebug() << "Authenticated";

    network.getRequest(baseUrl);
}

/*
 *  Send request to authenticate with device's MAC and 4 digit keycode
 *  Return true or false
 */
bool Client::authenticateDevice()
{
#ifdef DEBUG
    bool success = true;
#else
    bool success = false;
#endif
    return success;
}
