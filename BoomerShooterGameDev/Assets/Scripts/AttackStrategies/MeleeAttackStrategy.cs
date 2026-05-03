using UnityEngine;

public class MeleeAttackStrategy : IAttackStrategy
{
    private readonly float _damage;
    private readonly LayerMask _hitMask;
    public MeleeAttackStrategy(float damage, LayerMask hitMask)
    {
        _damage = damage;
        _hitMask = hitMask;
    }
    public bool CanAttack() => true;

    public void Execute(WeaponCore weapon) 
    //This script just calls the event because the damage
    //is handled through the animator and collisions
    {
        weapon.RaiseOnFire();
    }
}
