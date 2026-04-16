using UnityEngine;

public class EnemyOrbWeapon : EnemyRangedCore
{
    [SerializeField] private  GameObject _projectilePrefab;


    private void Awake()
    {
        SetAttackStrategy(new ProjectileAttackStrategy(
            damage: 15f,
            projectilePrefab: _projectilePrefab,
            travelSpeed: 10f,
            projectileLifetime: 3f));
    }
}