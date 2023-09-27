using UnityEngine;

public class WeaponHands : Weapon
{
    public Collider[] EnemyColliders { get; set; }
    private Enemy _enemy;

    public override void Attack()
    {
        foreach (Collider collider in EnemyColliders)
        {
            if (_enemy = collider.gameObject.GetComponentInChildren<Unit>())
            {
                _enemy.TakeDamage(WeaponParameters.AttackDamage);
                TimerBulletDelay = WeaponParameters.AttackDelay;
                return;
            }
        }
    }
}
