//AI and forums
using UnityEngine;
using System;

public class WeaponCore : MonoBehaviour
{
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] protected float _fireRate = 10f;
    [SerializeField] private int _damage = 10;
    public event Action OnFire;
    public event Action OnEquip;
    public event Action OnUnequip;

    public Transform MuzzleTransform => _muzzleTransform;
    public int Damage => _damage;

    protected IAttackStrategy AttackStrategy { get; private set; }

    protected float _nextFireTime;
    public bool IsEquipped { get; private set; }

    public void SetAttackStrategy(IAttackStrategy strategy) => AttackStrategy = strategy;

    public virtual void TryFire()
    {
        if (!IsEquipped)               return;
        if (AttackStrategy == null)      return;
        if (!AttackStrategy.CanAttack()) return;
        if (Time.time < _nextFireTime)   return;

        Debug.Log("Firing weapon!");

        _nextFireTime = Time.time + (1f / _fireRate);

        AttackStrategy.Execute(this);
        OnFire?.Invoke();
    }
    public void RaiseOnFire() => OnFire?.Invoke();
    public void Equip()
    {
        IsEquipped = true;
        gameObject.SetActive(true);
        OnEquip?.Invoke();
    }

    public void Unequip()
    {
        IsEquipped = false;
        gameObject.SetActive(false);
        OnUnequip?.Invoke();
    }

}
