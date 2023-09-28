using UnityEngine;

public class TakeUpgradePoints : Singleton<TakeUpgradePoints>
{
    [SerializeField] private UpgradePointsParameters _upgradePointsParameters;
    
    public void TakeGems()
    {
        var timer = PointsTimer.Instance;
        
        foreach (float gemTime in _upgradePointsParameters.TimesToPoints)
        {
            if (gemTime <= timer.RemainingTimeInProcent)
            {
                GameInformation.Instance.Information.UpgradePoints += _upgradePointsParameters.NumOfPoints;
            }
        }
        
        GameInformation.OnInformationChange?.Invoke();
    }

    private void OnDestroy()
    {
        LevelProgress.Instance.OnCompletedLevel -= TakeGems;
    }
}
