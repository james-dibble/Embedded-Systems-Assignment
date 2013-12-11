#include <QCoreApplication>
#include <QtMultimediaKit/QMediaPlayer>
//#include <QtMobility/qmobilityglobal.h>

#include <iostream>

using namespace std;

void playAudioFile(QString track);

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    QString audio_one = "mms://esd.jdibble.biz:8080/ESD/levels.mp3";
    QString audio_two = "http://www.wavsource.com/snds_2013-11-17_1534218342679325/animals/bird.wav";
    QString audio_three = "http://www.wavsource.com/snds_2013-11-17_1534218342679325/animals/cow3.wav";

    int selected = 0;

    while (1)
    {
        cout << "Enter track number: ";
        cin >> selected;

        switch(selected)
        {
        case 1:
            cout << "Track streaming from: " << audio_one.toStdString() << endl;
            playAudioFile(audio_one);
            break;
        case 2:
            cout << "Track streaming from: " << audio_two.toStdString() << endl;
            playAudioFile(audio_two);
            break;
        case 3:
            cout << "Track streaming from: " << audio_three.toStdString() << endl;
            playAudioFile(audio_three);
            break;
        }
    }

    return a.exec();
}

void playAudioFile(QString track)
{
    QMediaPlayer *player;
    player = new QMediaPlayer;

    player->setMedia(QUrl(track));
    player->setVolume(100);
    player->play();
}

