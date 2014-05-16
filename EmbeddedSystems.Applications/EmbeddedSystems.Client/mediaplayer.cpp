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
    qDebug() << "Grabbing track: " << track;
    player->setMedia(track);
    player->setVolume(100); 

    player->play();
    qDebug() << "Playing track: " << track;
}

void MediaPlayer::playPauseHandle()
{
    QMediaPlayer::State state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
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
    bool muteState = player->isMuted();

    if (muteState)
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
    QMediaPlayer::State state = player->state();

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
    QMediaPlayer::State state = player->state();

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
    QMediaPlayer::State state = player->state();

    if (state == QMediaPlayer::State::PlayingState)
    {
        player->play();
    }
    else
    {
        qDebug() << "Not playing";
    }
}

void MediaPlayer::setVolume(int volumeValue)
{
    qDebug() << "New Volume: " << volumeValue;

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
