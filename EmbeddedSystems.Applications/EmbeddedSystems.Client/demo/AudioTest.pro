#-------------------------------------------------
#
# Project created by QtCreator 2013-12-10T18:08:23
#
#-------------------------------------------------

QT       += core
#multimedia
QT       -= gui

TARGET = AudioTest
CONFIG   += console mobility
CONFIG   -= app_bundle

MOBILITY = multimedia


#QMAKE_CC                = arm-none-linux-gnueabi-gcc
#QMAKE_CXX               = arm-none-linux-gnueabi-g++
#QMAKE_LINK              = arm-none-linux-gnueabi-g++
#QMAKE_LINK_SHLIB        = arm-none-linux-gnueabi-g++

# modifications to linux.conf
#QMAKE_AR                = arm-none-linux-gnueabi-ar cqs
#QMAKE_OBJCOPY           = arm-none-linux-gnueabi-objcopy
#QMAKE_STRIP             = arm-none-linux-gnueabi-strip

#QMAKE_CXX = arm-linux-gnueabi-g++
#QMAKE_CXXFLAGS += -I/usr/include/QtMultimediaKit -I/usr/include/QtMobility -lQtMultimediaKit

TEMPLATE = app


SOURCES += main.cpp

