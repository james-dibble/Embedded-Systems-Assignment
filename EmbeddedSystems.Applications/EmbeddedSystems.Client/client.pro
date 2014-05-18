#-------------------------------------------------
#
# Project created by QtCreator 2014-02-06T10:38:16
#
#-------------------------------------------------

QT       += core network

QT       -= gui

TARGET = client
CONFIG   += console mobility serialport
CONFIG   -= app_bundle

MOBILITY = multimedia

TEMPLATE = app


SOURCES += main.cpp \
    client.cpp \
    network.cpp \
    locationtracker.cpp \
    keypadcontroller.cpp \
    mediaplayer.cpp
#    lcdcontroller.cpp


HEADERS += \
    client.h \
    clientIncludes.h \
    network.h \
    locationtracker.h \
    keypadcontroller.h \
    mediaplayer.h
#    lcdcontroller.h

QMAKE_CXXFLAGS += -std=c++11

INCLUDEPATH += /usr/include/QtMultimediaKit
INCLUDEPATH += /usr/include/QtMobility
INCLUDEPATH += jsoncpp-src-0.6.0-rc2/include
# INCLUDEPATH += /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/include
#               /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/src/lib_json

#LIBS += -L./jsoncpp-src-0.6.0-rc2/libs/linux-gcc-4.7/libjson_linux-gcc-4.7_libmt.a
LIBS += -L/home/greg/Documents/embedded/Embedded-Systems-Assignment/EmbeddedSystems.Applications/EmbeddedSystems.Client/jsoncpp-src-0.6.0-rc2/libs/linux-gcc-4.7/ -ljson
# LIBS += /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/libs/linux-gcc-4.7.2/libjson_linux-gcc-4.7.2_libmt.a

message($$LIBS)
