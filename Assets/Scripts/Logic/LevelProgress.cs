using System;
using System.Runtime.InteropServices;

public class LevelProgress : Singleton<LevelProgress>
{
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    private int _countKillsOnLevel;

    public int CountKillsOnLevel 
    {
        get { return _countKillsOnLevel; }
        set
        {
            _countKillsOnLevel = value;
            float progress = (float)_countKillsOnLevel / RequiredNumberOfKills;
            LevelProgressUI.Instance.UpdateProgressIndicator(progress);

            private float _completionThreshold = 1.0f;

            private int _frequencyLevelsDisplayingAdvertisements = 2;

            private int _equalizer = 0;
            
            if (progress >= _completionThreshold)
            {
                OnCompletedLevel?.Invoke();
                if (GameInformation.Instance.Information.PassedLevel % _frequencyLevelsDisplayingAdvertisements == _equalizer) 
                    AdvertisementController.Instance.ButtonReward.transform.localScale = UnityEngine.Vector3.one;
            }
        }
    }

    public int RequiredNumberOfKills { get; set; }

    public Action OnCompletedLevel;

    private void Start()
    {
        OnCompletedLevel += UpdateLevelParameters;
    }

    private void UpdateLevelParameters()
    {
        private int _initialValue = 0;
        
        CountKillsOnLevel = _initialValue ;
        LevelProgressUI.Instance.UpdateLevelNumText(++GameInformation.Instance.Information.PassedLevel);
        
        #if UNITY_WEBGL && !UNITY_EDITOR
        
        SetToLeaderboard(GameInformation.Instance.Information.PassedLevel);
        
        #endif
        
        GameInformation.OnInformationChange?.Invoke();
    }

    private void OnDestroy()
    {
        OnCompletedLevel -= UpdateLevelParameters;
        OnCompletedLevel = null;
    }
}
