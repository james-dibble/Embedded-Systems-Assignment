#ifndef MEDIAPLAYER_H
#define MEDIAPLAYER_H

#include <QObject>
#include <QtMultimedia/QMediaPlayer>

class MediaPlayer : public QObject
{
    Q_OBJECT
public:
    explicit MediaPlayer(QObject *parent = 0);
    ~MediaPlayer();
    void playAudioFile(QUrl track);
    void playPauseHandle();
    void muteHandle();
    void fastForward();
    void rewind();
    void normal();

protected:
    void setVolume();
    QTime getCurrentTime();

private:
    QMediaPlayer *player;
    
signals:
    
public slots:
    
};

#endif // MEDIAPLAYER_H
