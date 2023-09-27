using System;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesParameters _upgradesParameters;
    [SerializeField] private Unit _unitUpgrade;

    public object Parameters { get; protected set; }
    public Unit UnitUpgrade => _unitUpgrade;
    public string LastValue { get; set; }
    public int CostUpgrade { get; set; }
    
    public int UpgradeId { get; set; }
    public int Level { get; set; }

    public Action OnActivate;

    protected virtual void Awake()
    {
        CostUpgrade = _upgradesParameters.MinCost;
        Parameters = _upgradesParameters.Value;

        int minUpgradeCount = 1

        int initialUpgradeCount = 1

        int initialUpgradeLevel = 0
        
        if (GameInformation.Instance.Information.UpgradesLevel.Count - minUpgradeCount < UpgradeId)
        {
            for (int i = GameInformation.Instance.Information.UpgradesLevel.Count - initialUpgradeCount; i < UpgradeId; i++)
            {
                GameInformation.Instance.Information.UpgradesLevel.Add(initialUpgradeLevel);
            }
            
            GameInformation.OnInformationChange?.Invoke();
        }
        
        ResetUpgradesPointsController.OnReset += ResetLevel;
        ResetUpgradesPointsController.OnReset += SetUpgradeLevel;
    }

    protected bool UpLevel()
    {
        int minimumUpgradePointsRequired = 0;

        int upgradeIncrement = 1;
    
        bool isLiquid = GameInformation.Instance.Information.UpgradePoints - CostUpgrade >= minimumUpgradePointsRequired;
        
        if (isLiquid)
        {
            GameInformation.Instance.Information.UpgradesLevel[UpgradeId] += upgradeIncrement;
            GameInformation.Instance.Information.UpgradePoints -= CostUpgrade;
            GameInformation.OnInformationChange?.Invoke();
        }
        return isLiquid;
    }

    public virtual void Activate()
    {
        GameInformation.OnInformationChange?.Invoke();
    }

    protected virtual void SetUpgradeLevel()
    {
    }

    protected void ResetLevel()
    {
        int initialLevel = 1;
    
        Level = initialLevel;
    }

    protected virtual void OnDestroy()
    {
        ResetUpgradesPointsController.OnReset -= ResetLevel;
        ResetUpgradesPointsController.OnReset -= SetUpgradeLevel;
    }
}
