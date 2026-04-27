using UnityEngine;

public class Shotgun : RangedWeaponCore
{
    [SerializeField] private LayerMask _hitMask;

    private void Awake()
    {
        base.Awake();
        SetAttackStrategy(new HitScanAttackStrategy(
            range: 20f,
            damage: 15f,
            hitMask: _hitMask,
            spreadAngle: 12f,
            pelletCount: 8));
    }
}