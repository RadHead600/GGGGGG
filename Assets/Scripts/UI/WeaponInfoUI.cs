using TMPro;
using UnityEngine;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackDelay;
    [SerializeField] private TextMeshProUGUI _attackSpeed;

    public void DemonstrationWeaponInformation(Weapon weapon)
    {
        var info = weapon.WeaponParameters;
        _attackDelay.text = info.AttackDelay.ToString();
        _attackSpeed.text = info.AttackSpeed.ToString();
    }
}
