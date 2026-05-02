using UnityEngine;

public class Shotgun : RangedWeaponCore
{
    [SerializeField] private LayerMask _hitMask;

    protected override void Awake()
    {
        _fireRate = .75f;
        base.Awake();
        SetAttackStrategy(new HitScanAttackStrategy(
            range: 20f,
            damage: 15f,
            hitMask: _hitMask,
            spreadAngle: 12f,
            pelletCount: 8));
    }
}