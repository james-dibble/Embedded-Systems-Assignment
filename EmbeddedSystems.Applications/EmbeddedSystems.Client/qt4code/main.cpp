#include <QCoreApplication>
#include <QtMultimedia/QMediaPlayer>
#include <iostream>
#include <QTime>

using namespace std;

void playAudioFile(QString track);
QMediaPlayer::State pauseHandle(QMediaPlayer *player);
bool muteHandle(QMediaPlayer *player);
void setVolume(QMediaPlayer *player);
QTime getCurrentTime(QMediaPlayer *player);

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    QString audio_one = "mms://esd.jdibble.biz:8080/ESD/levels.mp3";
    QString audio_two = "mms://esd.jdibble.biz:8080/ESD/Dancing.mp3";

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
        }
    }

    return a.exec();
}

void playAudioFile(QString track)
{
    int selected;
    QMediaPlayer *player;
    player = new QMediaPlayer;

    player->setMedia(QUrl(track));
    player->setVolume(100);
    player->play();

    cout << "Playing track: " << track.toStdString() << endl;

    while(player->state() == QMediaPlayer::PlayingState)
    {

        cout << "Stop (0), Pause (1), Mute/Unmute (2), Volume (3): ";
        cin >> selected;

        switch(selected)
        {
        case 0: player->stop();
            break;
        case 1: pauseHandle(player);
            break;
        case 2: muteHandle(player);
            break;
        case 3: setVolume(player);
            break;
        default: pauseHandle(player);
        }
    }
    cout << "Stopped track: " << track.toStdString() << endl;
}

QMediaPlayer::State pauseHandle(QMediaPlayer *player)
{
    int selected;
    player->pause();
    cout << "Paused track..." << endl;
    cout << "Position: " << getCurrentTime(player).toString("mm:ss").toStdString() << endl;
    cout << "Stop (0), Play (1): ";
    cin >> selected;

    switch(selected)
    {
    case 0: player->stop();
        break;
    case 1: player->play();
        break;
    default: player->play();
    }

    return player->state();
}

bool muteHandle(QMediaPlayer *player)
{
    bool muteState = player->isMuted();

    if (muteState)
    {
        // Audio is muted
        player->setMuted(false); // Unmute audio
        cout << "Audio unmuted..." << endl;
    } else {
        // Audio is not muted
        player->setMuted(true); // Mute audio
        cout << "Audio muted..." << endl;
    }
    cout << "Volume: " << player->volume() << endl;
    cout << "Position: " << getCurrentTime(player).toString("mm:ss").toStdString() << endl;

    return muteState;
}

void setVolume(QMediaPlayer *player)
{
    int volumeValue;
    cout << "New Volume: ";
    cin >> volumeValue;

    player->setVolume(volumeValue);

}

QTime getCurrentTime(QMediaPlayer *player)
{
    qint64 position = player->position();

    int seconds = (position/1000) % 60;
    int minutes = (position/60000) % 60;
    int hours = (position/3600000) % 24;

    QTime time;
    time.setHMS(hours, minutes, seconds);

    return time;
}

