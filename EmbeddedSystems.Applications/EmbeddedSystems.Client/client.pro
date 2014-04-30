#-------------------------------------------------
#
# Project created by QtCreator 2014-02-06T10:38:16
#
#-------------------------------------------------

QT       += core network

QT       -= gui

TARGET = client
CONFIG   += console
CONFIG   -= app_bundle

TEMPLATE = app


SOURCES += main.cpp \
    client.cpp \
    network.cpp \
    locationtracker.cpp \
    keypadcontroller.cpp \
    lcdcontroller.cpp \
    mediaplayer.cpp

HEADERS += \
    client.h \
    clientIncludes.h \
    network.h \
    locationtracker.h \
    keypadcontroller.h \
    lcdcontroller.h \
    mediaplayer.h

QMAKE_CXXFLAGS += -std=c++11

INCLUDEPATH += ../../../../jsoncpp-src-0.6.0-rc2/include
# INCLUDEPATH += /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/include
#               /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/src/lib_json

LIBS += ../../../../jsoncpp-src-0.6.0-rc2/libs/linux-gcc-4.7/libjson_linux-gcc-4.7_libmt.a
# LIBS += /home/netlab/gmasters/Documents/embedded/jsoncpp-src-0.6.0-rc2/libs/linux-gcc-4.7.2/libjson_linux-gcc-4.7.2_libmt.a
