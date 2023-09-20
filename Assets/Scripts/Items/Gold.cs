using UnityEngine;

public class Gold : Item
{
    [Header("How much currency does the player get for one raised coin")]
    [SerializeField] private int _amountCurrency;
    [SerializeField] private float _lifeTime;

    public override void Active()
    {
        GameInformation.Instance.Information.Golds += _amountCurrency;
        Destroy(gameObject, _lifeTime);
    }
}
