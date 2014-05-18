#include "mediaplayer.h"

MediaPlayer::MediaPlayer(QObject *parent) :
    QObject(parent)
{
    player = new QMediaPlayer();
    volume = 100;
}

MediaPlayer::~MediaPlayer()
{
}

void MediaPlayer::playAudioFile(QUrl track)
{
    qDebug() << "Grabbing track: " << track;
    player->setMedia(track);
    player->setVolume(volume);

    player->play();
    qDebug() << "Playing track: " << track;
}

void MediaPlayer::playPauseHandle()
{
    if (player->state() == QMediaPlayer::PlayingState)
    {
        player->pause();
    }
    else
    {
        player->play();
    }
    qDebug() << "Paused track..." << endl;
    qDebug() << "Position: " << getCurrentTime().toString("mm:ss");
}

void MediaPlayer::muteHandle()
{
    if (player->isMuted())
    {
        // Audio is muted
        player->setMuted(false); // Unmute audio
        qDebug() << "Audio unmuted...";
    } else {
        // Audio is not muted
        player->setMuted(true); // Mute audio
        qDebug() << "Audio muted...";
    }
    qDebug() << "Volume: " << player->volume() << endl;
    qDebug() << "Position: " << getCurrentTime().toString("mm:ss");
}

void MediaPlayer::fastForward()
{
    if (player->state() == QMediaPlayer::PlayingState)
    {
        // player->fastforward();
    }
    else
    {
        qDebug() << "Not playing";
    }
}

void MediaPlayer::rewind()
{
    if (player->state() == QMediaPlayer::PlayingState)
    {
        // player->rewind();
    }
    else
    {
        qDebug() << "Not playing";
    }
}

void MediaPlayer::normal()
{
    if (player->state() == QMediaPlayer::PlayingState)
    {
        player->play();
    }
    else
    {
        qDebug() << "Not playing";
    }
}

void MediaPlayer::changeVolume(bool up)
{
    qDebug() << "Volume is: " << volume;

    if (up && volume < 100)
    {
        volume += 25;
    }
    else if (!up && volume > 0)
    {
        volume -= 25;
    }
    player->setVolume(volume);
}

QTime MediaPlayer::getCurrentTime()
{
    qint64 position = player->position();

    int seconds = (position/1000) % 60;
    int minutes = (position/60000) % 60;
    int hours = (position/3600000) % 24;

    QTime time;
    time.setHMS(hours, minutes, seconds);

    return time;
}
