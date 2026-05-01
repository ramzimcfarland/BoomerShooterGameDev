using UnityEngine;
using System;
using System.Collections;

public abstract class MeleeWeaponCore : WeaponCore
{
    private float _radius = 1f;
    protected virtual void Awake()
    {
        
    }

    public void CheckHit()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        foreach(var col in hits)
        {
            if (col.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage(10f);
            }
        }
    }
}
