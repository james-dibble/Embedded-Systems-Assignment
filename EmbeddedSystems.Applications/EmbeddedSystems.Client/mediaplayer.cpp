#include "mediaplayer.h"

MediaPlayer::MediaPlayer(QObject *parent) :
    QObject(parent)
{
    player = new QMediaPlayer();
}

MediaPlayer::~MediaPlayer()
{
}

void MediaPlayer::playAudioFile(QUrl track)
{
    player->setMedia(track);
    player->setVolume(100);
//    player->play();

    qDebug() << "Playing track: " << track.toStdString() << endl;
}

void MediaPlayer::playPauseHandle()
{
    QMediaPlayer state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
    {
        player->pause();
    }
    else
    {
        player->play();
    }
    qDebug() << "Paused track..." << endl;
    qDebug() << "Position: " << getCurrentTime().toString("mm:ss").toStdString() << endl;
}

void MediaPlayer::muteHandle()
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
    qDebug() << "Volume: " << player->volume() << endl;
    qDebug() << "Position: " << getCurrentTime().toString("mm:ss").toStdString() << endl;
}

void MediaPlayer::fastForward()
{
    QMediaPlayer state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
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
    QMediaPlayer state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
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
    QMediaPlayer state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
    {
        player->play();
    }
    else
    {
        qDebug() << "Not playing";
    }
}

void MediaPlayer::setVolume()
{
    int volumeValue;
    qDebug() << "New Volume: ";
    qDebug() >> volumeValue;

    player->setVolume(volumeValue);

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
