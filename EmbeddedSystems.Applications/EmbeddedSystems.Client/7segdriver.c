
#include <errno.h>
#include <termios.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <fcntl.h>



int set_interface_attribs (int fd, int speed, int parity)
{
        struct termios tty;
        memset (&tty, 0, sizeof tty);
        if (tcgetattr (fd, &tty) != 0)
        {
                printf("error %d from tcgetattr", errno);
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
                printf("error %d from tcsetattr", errno);
                return -1;
        }
        return 0;
}

void set_blocking (int fd, int should_block)
{
        struct termios tty;
        memset (&tty, 0, sizeof tty);
        if (tcgetattr (fd, &tty) != 0)
        {
                printf("error %d from tggetattr", errno);
                return;
        }

        tty.c_cc[VMIN]  = should_block ? 1 : 0;
        tty.c_cc[VTIME] = 5;            // 0.5 seconds read timeout

        if (tcsetattr (fd, TCSANOW, &tty) != 0)
                printf("error %d setting term attributes", errno);
}



int main (int argc, char **argv)
{

char *portname = "/dev/ttyACM1";

int fd = open(portname, O_RDWR);

if (fd < 0)
{
        printf("error %d opening %s: %s", errno, portname, strerror (errno));
        return 0;
}

set_interface_attribs (fd, B115200, 0);  // set speed to 115,200 bps, 8n1 (no parity)
set_blocking (fd, 0);                // set no blocking

write (fd, "@00P200\r", 8);           // Light up first 7seg2
write (fd, "@00P000\r", 8);           // Light up first 7seg
usleep(200);
write (fd, "@00P206\r", 8);           // Light up first 7seg2
write (fd, "@00P001\r", 8);           // Light up first 7seg
usleep(200);

write (fd, "@00P25B\r", 8);           // Light up first 7seg2
write (fd, "@00P001\r", 8);           // Light up first 7seg
usleep(200);

write (fd, "@00P24F\r", 8);           // Light up first 7seg2
write (fd, "@00P001\r", 8);           // Light up first 7seg
usleep(200);

write (fd, "@00P266\r", 8);           // Light up first 7seg2
write (fd, "@00P001\r", 8);           // Light up first 7seg
usleep(200);



//printf("Done");
sleep(1);


return 0;
}
