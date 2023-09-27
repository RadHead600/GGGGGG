using System;
using TMPro;
using UnityEngine;

public class ResetUpgradesPointsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private int _resetCost;

    public static event Action OnReset;

    void Start()
    {
        _costText.text = _resetCost.ToString();
    }

    public void ResetPoints()
    {
        if (GameInformation.Instance != null && GameInformation.Instance.Information.Golds - _resetCost >= 0)
        {
            int countPoints = 0;
            for (int i = 0; i < GameInformation.Instance.Information.UpgradesLevel.Count; i++)
            {
                countPoints += GameInformation.Instance.Information.UpgradesLevel[i];
                GameInformation.Instance.Information.UpgradesLevel[i] = 0;
            }
            if (countPoints > 0)
            {
                GameInformation.Instance.Information.Golds -= _resetCost;
                GameInformation.Instance.Information.UpgradePoints += countPoints;
                GameInformation.OnInformationChange?.Invoke();
                OnReset?.Invoke();
            }
        }
    }
}
