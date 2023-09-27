using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : Singleton<LevelProgressUI>
{
    [SerializeField] private Image _progressIndicator;
    [SerializeField] private TextMeshProUGUI _levelNumText;

    public void UpdateProgressIndicator(float value)
    {
        _progressIndicator.fillAmount = value;
    }

    public void UpdateLevelNumText(int num)
    {
        int initialProgress = 0;
        
        _levelNumText.text = num.ToString();
        UpdateProgressIndicator(initialProgress);
    }
}
