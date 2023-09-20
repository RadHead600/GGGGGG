using UnityEngine;

public class ItemsPanel : MonoBehaviour
{
    public ShopItemCard[] ShopItemCards
    {
        get; private set;
    }

    private void Awake()
    {
        ShopItemCards = GetItems();
    }

    private void OnEnable()
    {
        if (ShopItemCards == null)
            ShopItemCards = GetItems();
    }

    private ShopItemCard[] GetItems()
    {
        return GetComponentsInChildren<ShopItemCard>();
    }
}
