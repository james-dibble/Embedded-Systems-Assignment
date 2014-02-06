#ifndef CLIENT_H
#define CLIENT_H

#include "clientIncludes.h"
#include "network.h"

class Client
{
public:
    Client();
    ~Client();

    void startClient();
    bool authenticateDevice();

private:
    Network network;


};

#endif // CLIENT_H

// colon base 64
