using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemCard : MonoBehaviour
{
    [SerializeField] private Button _itemButton;
    [SerializeField] private TextTranslator _buttonKeyText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextTranslator _textTranslator;
    [SerializeField] private Image _moneyImage;
    [SerializeField] private GameObject _ItemDemonstrationObject;

    public Button ItemButton => _itemButton;
    public TextTranslator ButtonKeyText => _buttonKeyText;
    public TextMeshProUGUI CostText => _costText;
    public TextTranslator TextTranslator => _textTranslator;
    public Image MoneyImage => _moneyImage;
    public GameObject ItemDemonstrationObject => _ItemDemonstrationObject;
}
