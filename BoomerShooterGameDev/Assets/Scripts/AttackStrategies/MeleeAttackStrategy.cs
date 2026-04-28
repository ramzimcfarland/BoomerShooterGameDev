using UnityEngine;

public class MeleeAttackStrategy : IAttackStrategy
{
    private readonly float _range;
    private readonly float _damage;
    private readonly LayerMask _hitMask;

    public MeleeAttackStrategy(float range, float damage, LayerMask hitMask)
    {
        _range = range;
        _damage = damage;
        _hitMask = hitMask;
    }
    public bool CanAttack() => true;

    public void Execute(WeaponCore weapon)
    {
        
    }
}
