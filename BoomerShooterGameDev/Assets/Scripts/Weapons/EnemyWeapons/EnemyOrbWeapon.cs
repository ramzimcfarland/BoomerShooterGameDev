using UnityEngine;

public class EnemyOrbWeapon : RangedWeaponCore
{
    [SerializeField] private  GameObject _projectilePrefab;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float travelSpeed = 5f;
    [SerializeField] private float projectileLifetime = 3f;

    protected override void Awake()
    {
        base.Awake();
        SetAttackStrategy(new ProjectileAttackStrategy(
            damage: 15f,
            projectilePrefab: _projectilePrefab,
            travelSpeed: travelSpeed,
            projectileLifetime: projectileLifetime));
    }
}