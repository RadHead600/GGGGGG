using System;
using UnityEngine;

[Serializable]
public class ShopItem
{
    [SerializeField] private string _wordsKeyTranslatorText;
    [SerializeField] private int _itemCost;
    [SerializeField] private ItemMoneyType _moneyType;
    [SerializeField] private GameObject _itemObject;

    public string WordsKeyTranslatorText => _wordsKeyTranslatorText;
    public int ItemCost => _itemCost;
    public ItemMoneyType MoneyType => _moneyType;
    public GameObject ItemObject => _itemObject;
}

public enum ItemMoneyType
{
    Gem,
    Gold,
    Level
} 