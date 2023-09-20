using UnityEngine;

public class AudioListenerController : Singleton<AudioListenerController>
{
    public void ChangeAuidoListener()
    {
        if (AudioListener.volume > 0)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }

    public  void SetAudioListerner(float value)
    {
        AudioListener.volume = value;
    }
}
