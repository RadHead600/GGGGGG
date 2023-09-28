using UnityEngine;

public class AudioListenerController : Singleton<AudioListenerController>
{
    private const float AudioVolumeOff = 0f;
    private const float AudioVolumeOn = 1f;
    
    public void ChangeAuidoListener()
    {
        if (AudioListener.volume > AudioVolumeOff)
            AudioListener.volume = AudioVolumeOff;
        else
            AudioListener.volume = AudioVolumeOn;
    }

    public  void SetAudioListerner(float value)
    {
        AudioListener.volume = value;
    }
}
