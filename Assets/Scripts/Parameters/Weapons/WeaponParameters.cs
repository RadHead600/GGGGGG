using UnityEngine;

[CreateAssetMenu(fileName = "WeaponParameters.Asset", menuName = "CustomParameters/Weapons/WeaponParameters")]
public class WeaponParameters : ScriptableObject
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Bullet _bullet;

    public int AttackDamage => _attackDamage;
    public float AttackSpeed => _attackSpeed;
    public float AttackDelay => _attackDelay;
    public Bullet Bullet => _bullet;
}