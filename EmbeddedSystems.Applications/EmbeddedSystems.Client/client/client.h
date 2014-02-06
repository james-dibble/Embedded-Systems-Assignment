#ifndef CLIENT_H
#define CLIENT_H

#include "clientIncludes.h"
#include "networkclass.h"

class Client
{
public:
    Client();
    ~Client();

    void startClient();
    bool authenticateDevice();

private:
    NetworkClass network;
};

#endif // CLIENT_H
