using UnityEngine;
using UnityEngine.UI;

public class HealthChangeBarUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Unit _unit;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _unit.OnHealthChange += UpdateSlider;
        _healthSlider.maxValue = _unit.Health;
        StartGameController.Instance.OnStartGame += UpdateMaxValueSlider;
        UpdateSlider(_unit.Health);
    }

    private void FixedUpdate()
    {
        if (_canvas.transform.rotation != Camera.main.transform.rotation)
            _canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void UpdateSlider(int value)
    {
        _healthSlider.value = value;
    }

    private void UpdateMaxValueSlider()
    {
        _healthSlider.maxValue = _unit.Health;
        UpdateSlider(_unit.Health);
    }

    private void OnDestroy()
    {
        StartGameController.Instance.OnStartGame += UpdateMaxValueSlider;
    }
}
