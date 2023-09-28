using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopParameters _shopParameters;
    [SerializeField] private ShopItemCard _itemCard;
    [SerializeField] private ItemsPanel _itemsPanel;
    [SerializeField] private PlayerItemUpdate _character;
    [SerializeField] private string _isEquipedKeyText;
    [SerializeField] private string _isEquipKeyText;
    [SerializeField] private ShopType _shopType;
    
    private int _lastEquipedButton;

    public ShopParameters ShopParameters => _shopParameters;

    private void Awake()
    {
        CreateItemCards();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void CreateItemCards()
    {
        for (int i = 0; i < _shopParameters.Items.Count; i++)
        {
            int saveI = i;
            ShopItemCard card = Instantiate(_itemCard);
            card.transform.SetParent(_itemsPanel.transform);
            card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y, 0);
            card.transform.localScale = Vector3.one;
            card.transform.localPosition = Vector3.zero;
            card.ItemButton.onClick.AddListener(() => BuyItem(saveI));
            GameObject objectDemonstration = Instantiate(_shopParameters.Items[i].ItemObject);
            objectDemonstration.transform.SetParent(card.ItemDemonstrationObject.transform);
            objectDemonstration.transform.localRotation = _shopParameters.Items[i].ItemObject.transform.localRotation;
            objectDemonstration.transform.localPosition = Vector3.zero;
            objectDemonstration.transform.localScale = new Vector3(_shopParameters.Items[i].ItemObject.transform.localScale.x, _shopParameters.Items[i].ItemObject.transform.localScale.y, _shopParameters.Items[i].ItemObject.transform.localScale.z);
            card.CostText.text = _shopParameters.Items[i].ItemCost.ToString();
            card.TextTranslator.key = _shopParameters.Items[i].WordsKeyTranslatorText;
            
            if (_shopType == ShopType.Weapon)
                card.GetComponent<WeaponInfoUI>().DemonstrationWeaponInformation(_shopParameters.Items[i].ItemObject.GetComponent<Weapon>());
                
            Sprite moneySprite = _shopParameters.MoneySprites[((int)_shopParameters.Items[i].MoneyType)];
            
            if (moneySprite != null)
                card.MoneyImage.sprite = moneySprite;
        }
    }

    public void Equip(int itemNum)
    {
        _character.SetItem(_shopParameters.Items[itemNum], itemNum);
        _itemsPanel.ShopItemCards[_lastEquipedButton].ItemButton.interactable = true;
        _itemsPanel.ShopItemCards[itemNum].ItemButton.interactable = false;
        ChangeItemPanelButtonText(_lastEquipedButton, _isEquipKeyText);
        ChangeItemPanelButtonText(itemNum, _isEquipedKeyText);
        _lastEquipedButton = itemNum;
    }

    public void UnlockItems(List<int> items)
    {
        foreach (int itemNum in items)
        {
            Unlockitem(itemNum, _isEquipKeyText);
        }
    }

    private void BuyItem(int itemNum)
    {
        int cost = _shopParameters.Items[itemNum].ItemCost;
        
        switch (_shopParameters.Items[itemNum].MoneyType)
        {
            case ItemMoneyType.Gold:
                if (GameInformation.Instance.Information.Golds < cost)
                    return;
                GameInformation.Instance.Information.Golds -= cost;
                break;
                
            case ItemMoneyType.Gem:
                if (GameInformation.Instance.Information.Gems < cost)
                    return;
                GameInformation.Instance.Information.Gems -= cost;
                break;
                
            case ItemMoneyType.Level:
                if (GameInformation.Instance.Information.PassedLevel < cost)
                    return;
                break;
            default:
                return;
        }
        switch (_shopType)
        {
            case ShopType.Skin:
                GameInformation.Instance.Information.SkinsBought.Add(itemNum);
                break;
                
            case ShopType.Weapon:
                GameInformation.Instance.Information.WeaponsBought.Add(itemNum);
                break;
        }
        
        _itemsPanel.ShopItemCards[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.ShopItemCards[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        Unlockitem(itemNum, _isEquipKeyText);
        GameInformation.OnInformationChange?.Invoke();
    }

    private void Unlockitem(int itemNum, string buttonText)
    {
        _itemsPanel.ShopItemCards[itemNum].CostText.alpha = 0;
        _itemsPanel.ShopItemCards[itemNum].MoneyImage.color = new Color(0, 0, 0, 0);
        _itemsPanel.ShopItemCards[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.ShopItemCards[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        ChangeItemPanelButtonText(itemNum, buttonText);
    }

    private void ChangeItemPanelButtonText(int itemNum, string text)
    {
        _itemsPanel.ShopItemCards[itemNum].ButtonKeyText.key = text;
        _itemsPanel.ShopItemCards[itemNum].ButtonKeyText.ReTranslate();
    }
}

public enum ShopType
{
    Skin,
    Weapon
}
