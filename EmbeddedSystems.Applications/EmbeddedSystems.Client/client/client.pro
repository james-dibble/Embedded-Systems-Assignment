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
    network.cpp

HEADERS += \
    client.h \
    clientIncludes.h \
    network.h

QMAKE_CXXFLAGS += -std=c++11
