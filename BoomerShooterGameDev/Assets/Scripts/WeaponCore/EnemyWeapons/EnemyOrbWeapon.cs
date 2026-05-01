using UnityEngine;

public class EnemyOrbWeapon : RangedWeaponCore
{
    [SerializeField] private  GameObject _projectilePrefab;
    [SerializeField] private LayerMask _layerMask;

    protected override void Awake()
    {
        base.Awake();
        SetAttackStrategy(new ProjectileAttackStrategy(
            damage: 15f,
            projectilePrefab: _projectilePrefab,
            travelSpeed: 5f,
            projectileLifetime: 3f));
    }
}