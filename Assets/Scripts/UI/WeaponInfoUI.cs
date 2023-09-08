using TMPro;
using UnityEngine;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackDelay;
    [SerializeField] private TextMeshProUGUI _attackSpeed;
    [SerializeField] private TextMeshProUGUI _attackDamage;

    public void DemonstrationWeaponInformation(Weapon weapon)
    {
        var info = weapon.WeaponParameters;
        _attackDelay.text = info.AttackDelay.ToString();
        _attackSpeed.text = info.AttackSpeed.ToString();
        _attackDamage.text = info.AttackDamage.ToString();
    }
}
