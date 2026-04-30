//AI
using UnityEngine;
using System;

public class WeaponCore : MonoBehaviour
{
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] protected float _fireRate = 10f;
    [SerializeField] private int _damage = 10;

    public Animator _animator;

    public event Action     OnFire;

    public Transform MuzzleTransform => _muzzleTransform;
    public int Damage => _damage;

    protected IAttackStrategy AttackStrategy { get; private set; }
    private float _nextFireTime;

    public void SetAttackStrategy(IAttackStrategy strategy) => AttackStrategy = strategy;

    public virtual void TryFire()
    {
        //if (!IsEquipped)               return;
        if (AttackStrategy == null)      return;
        if (!AttackStrategy.CanAttack()) return;
        if (Time.time < _nextFireTime)   return;

        _nextFireTime = Time.time + (1f / _fireRate);

        AttackStrategy.Execute(this);
        OnFire?.Invoke();
    }

}
