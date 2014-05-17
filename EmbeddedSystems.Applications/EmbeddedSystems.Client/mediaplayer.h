#ifndef MEDIAPLAYER_H
#define MEDIAPLAYER_H

#include <QObject>
//#include <QMediaPlayer>
#include <QTime>
#include <QtMultimediaKit/QMediaPlayer>

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
    void changeVolume(bool);

protected:
    QTime getCurrentTime();

private:
    QMediaPlayer *player;
    int volume;
    
signals:
    
public slots:
    
};

#endif // MEDIAPLAYER_H
