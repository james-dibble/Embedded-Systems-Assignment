# Swag Makefile

CC=g++
CFLAGS=-Wall -o
LFLAGS=
CROSS_COMPILE=

SOURCES=test

all:	$(SOURCES)

test:	test.cpp 
	$(CC) $^ $(CFLAGS) $@ $(LFLAGS)

clean: 
	rm -f $(SOURCES)
