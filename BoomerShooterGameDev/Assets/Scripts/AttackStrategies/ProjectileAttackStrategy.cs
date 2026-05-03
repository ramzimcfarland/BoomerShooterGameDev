using UnityEngine;

public class ProjectileAttackStrategy : IAttackStrategy
{
    private readonly float _damage;
    private readonly GameObject _projectilePrefab;
    private readonly float _travelSpeed;
    private readonly float _projectileLifetime;
    public ProjectileAttackStrategy( float damage, GameObject projectilePrefab,
     float travelSpeed, float projectileLifetime)
    {
        _damage = damage;
        _projectilePrefab = projectilePrefab;
        _travelSpeed = travelSpeed;
        _projectileLifetime = projectileLifetime;
    }
    public bool CanAttack() => true;
    public void Execute(WeaponCore weapon)
    {
        //Instatiate the projectile and launch it!
        var origin = weapon.MuzzleTransform.position;
        var forward = weapon.MuzzleTransform.forward;

        GameObject projectile = Object.Instantiate(_projectilePrefab, origin, 
        weapon.MuzzleTransform.rotation);

        projectile.GetComponent<Orb>().Init(_damage);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity = forward * _travelSpeed;

        Object.Destroy(projectile, _projectileLifetime);
    }
}
