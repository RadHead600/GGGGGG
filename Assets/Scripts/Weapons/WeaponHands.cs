using UnityEngine;

public class WeaponHands : Weapon
{
    public Collider[] EnemyColliders { get; set; }
    private Unit _unit;

    public override void Attack()
    {
        foreach (Collider collider in EnemyColliders)
        {
            if (_unit = collider.gameObject.GetComponentInChildren<Unit>())
            {
                _unit.TakeDamage(WeaponParameters.AttackDamage);
                TimerBulletDelay = WeaponParameters.AttackDelay;
                return;
            }
        }
    }
}
