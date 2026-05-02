using UnityEngine;

public class EnemyMeleeWeapon : MeleeWeaponCore
{
    [SerializeField] private LayerMask _hitMask;
    private void Awake()
    {
        SetAttackStrategy(new MeleeAttackStrategy(
            damage: Damage,
            hitMask: _hitMask));
    }
}