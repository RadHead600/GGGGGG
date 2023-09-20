using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Slider _timerSlider;

    private void Start()
    {
        PointsTimer.Instance.OnTimerUpdate += UpdateSlider;
    }

    private void UpdateSlider(float value)
    {
        _timerSlider.value = value;
    }

    private void OnDestroy()
    {
        PointsTimer.Instance.OnTimerUpdate -= UpdateSlider;
    }
}
