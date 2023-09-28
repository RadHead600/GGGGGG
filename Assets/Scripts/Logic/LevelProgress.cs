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
            
            if (progress >= 1)
            {
                OnCompletedLevel?.Invoke();
                if (GameInformation.Instance.Information.PassedLevel % 2 == 0) 
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
        CountKillsOnLevel = 0;
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
