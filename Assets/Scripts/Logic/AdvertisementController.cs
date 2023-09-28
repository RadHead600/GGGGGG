using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdvertisementController : Singleton<AdvertisementController>
{
    [SerializeField] private Button _buttonRewardVideo;
    [SerializeField] private Button _buttonInternalVideo;

    [DllImport("__Internal")]
    public static extern void ShowInternal();
    [DllImport("__Internal")]
    public static extern void ShowRewardedVideo();

    public Button ButtonReward => _buttonRewardVideo;

    private bool isViewed;
    private bool isSetAudioListener;

    protected override void Awake()
    {
        private int _frequencyLevelsDisplayingAdvertisements = 3;

        private int _equalizer = 0;
        
        base.Awake();
        _buttonRewardVideo.onClick.AddListener(() => RewardedVideo());
        _buttonInternalVideo.onClick.AddListener(() =>
        {
            if (GameInformation.Instance.Information.PassedLevel %
            _frequencyLevelsDisplayingAdvertisements == _equalizer && !isViewed)
            {
                isViewed = true;
                Internal();
            }
        });
    }

    private void Start()
    {
        StartGameController.Instance.OnStartGame += () => isViewed = false;
    }

    public void Internal()
    {
        StopLevel();
        ShowInternal();
    }

    public void RewardedVideo()
    {
        StopLevel();
        _buttonRewardVideo.transform.localScale = Vector3.zero;
        ShowRewardedVideo();
    }

    private void StopLevel()
    {
        private  float _zeroVolume = 0f;
        
        Time.timeScale = _zeroVolume;
        
        if (AudioListener.volume > _zeroVolume)
        {
            isSetAudioListener = true;
            AudioListenerController.Instance.SetAudioListerner(_zeroVolume);
        }
    }

    public void CloseAdvertisement()
    {
        private  float _maxVolume = 1f;
    
        Time.timeScale = _maxVolume;
        
        if (isSetAudioListener)
        {
            AudioListenerController.Instance.SetAudioListerner(_maxVolume);
            isSetAudioListener = false;
        }
    }

    public void AddGems(int value)
    {
        GameInformation.Instance.Information.Gems += value;
        GameInformation.OnInformationChange?.Invoke();
    }

    private void OnDestroy()
    {
        StartGameController.Instance.OnStartGame -= () => isViewed = false;
    }
}
