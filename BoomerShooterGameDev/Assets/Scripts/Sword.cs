using UnityEngine;

public class Sword : MeleeWeaponCore
{
    [SerializeField] LayerMask _hitMask;
    protected override void Awake()
    {
        base.Awake();
        SetAttackStrategy(new MeleeAttackStrategy(
            damage: 10f,
            hitMask: _hitMask));
    }
    void Update()
    {
        CheckHit();
    }
}
