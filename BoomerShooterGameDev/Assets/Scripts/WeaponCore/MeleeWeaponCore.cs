using UnityEngine;
using System;
using System.Collections;

public abstract class MeleeWeaponCore : WeaponCore
{
    [SerializeField] private float _attackCooldown = .2f;
    private bool _isAttacking;
    private float _nextAttackTime;
    public override void TryFire()
    
    {
        if(_isAttacking) return;
        if(Time.time < _nextAttackTime) return;

        _nextAttackTime = Time.time + _attackCooldown;
        _isAttacking = true;

        base.TryFire();
        StartCoroutine(AttackRoutine());
    }
    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(_attackCooldown);
        _isAttacking = false;
    }
    public override void Unequip()
    {
        StopAllCoroutines();
        _isAttacking = false;
        _nextAttackTime = 0f;

        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
        base.Unequip();
    }
}