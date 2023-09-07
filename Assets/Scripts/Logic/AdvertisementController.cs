using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class AdvertisementController : Singleton<AdvertisementController>
{
    [SerializeField] private Button _buttonRewardVideo;

    [DllImport("__Internal")]
    public static extern void ShowInternal();
    [DllImport("__Internal")]
    public static extern void ShowRewardedVideo();

    public Button ButtonReward => _buttonRewardVideo;

    private bool isSetAudioListener;

    protected override void Awake()
    {
        base.Awake();
        _buttonRewardVideo.onClick.AddListener(() => RewardedVideo());
    }

    public void Internal()
    {
#if UNITY_WEBGL
        StopLevel();
        ShowInternal();
#endif
    }

    public void RewardedVideo()
    {
        StopLevel();
        _buttonRewardVideo.transform.localScale = Vector3.zero;
        ShowRewardedVideo();
    }

    private void StopLevel()
    {
        Time.timeScale = 0;
        if (AudioListener.volume > 0)
        {
            isSetAudioListener = true;
            AudioListenerController.Instance.SetAudioListerner(0);
        }
    }

    public void CloseAdvertisement()
    {
        Time.timeScale = 1;
        if (isSetAudioListener)
        {
            AudioListenerController.Instance.SetAudioListerner(1);
            isSetAudioListener = false;
        }
    }

    // количество рекламной валюты настраивается в jslib документе в вызове функции 
    public void AddGems(int value)
    {
        GameInformation.Instance.Information.Gems += value;
        GameInformation.OnInformationChange?.Invoke();
    }
}
