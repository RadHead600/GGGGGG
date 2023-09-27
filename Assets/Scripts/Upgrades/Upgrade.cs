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
        
        if (GameInformation.Instance.Information.UpgradesLevel.Count - 1 < UpgradeId)
        {
            for (int i = GameInformation.Instance.Information.UpgradesLevel.Count - 1; i < UpgradeId; i++)
            {
                GameInformation.Instance.Information.UpgradesLevel.Add(0);
            }
            GameInformation.OnInformationChange?.Invoke();
        }
        ResetUpgradesPointsController.OnReset += ResetLevel;
        ResetUpgradesPointsController.OnReset += SetUpgradeLevel;
    }

    protected bool UpLevel()
    {
        bool isLiquid = GameInformation.Instance.Information.UpgradePoints - CostUpgrade >= 0;
        
        if (isLiquid)
        {
            GameInformation.Instance.Information.UpgradesLevel[UpgradeId] += 1;
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
        Level = 1;
    }

    protected virtual void OnDestroy()
    {
        ResetUpgradesPointsController.OnReset -= ResetLevel;
        ResetUpgradesPointsController.OnReset -= SetUpgradeLevel;
    }
}
