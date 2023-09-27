using TMPro;
using UnityEngine;

public class UpgradeUICard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private UpgradeTypeParameters _type;
    [SerializeField] private Upgrade _cardInformation;

    public TextMeshProUGUI InfoText => _infoText;
    public UpgradeTypeParameters Type => _type;
    public Upgrade CardInformation => _cardInformation;

    private void Start()
    {
        _cardInformation.OnActivate += UpdateInformation;
        UpdateInformation();
    }

    public virtual void UpdateInformation()
    {
        if (_type == UpgradeTypeParameters.Int)
        {
            _infoText.text = _cardInformation.LastValue + " >> " + (int)Sum();
            return;
        }
        
        _infoText.text = System.Math.Round(System.Convert.ToDouble(_cardInformation.LastValue),
        decimalPlaces) + " >> " + System.Math.Round(Sum(), decimalPlaces);
    }

    private double Sum()
    {
        return System.Convert.ToDouble(_cardInformation.LastValue) + System.Convert.ToDouble(_cardInformation.Parameters.ToString());
    }

    protected virtual void OnDestroy()
    {
        _cardInformation.OnActivate -= UpdateInformation;
    }
}

public enum UpgradeTypeParameters
{
    Int,
    Float
}
