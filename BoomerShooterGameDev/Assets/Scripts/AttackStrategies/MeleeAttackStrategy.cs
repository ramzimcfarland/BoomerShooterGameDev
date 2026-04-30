using UnityEngine;

public class MeleeAttackStrategy : IAttackStrategy
{
    private readonly float _damage;
    private readonly LayerMask _hitMask;

    public Animator _animator;

    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    public MeleeAttackStrategy(float damage, LayerMask hitMask)
    {
        _damage = damage;
        _hitMask = hitMask;
    }
    public bool CanAttack() => true;

    public void Execute(WeaponCore weapon)
    {
        weapon._animator.SetTrigger(AttackTrigger);
    }
}
