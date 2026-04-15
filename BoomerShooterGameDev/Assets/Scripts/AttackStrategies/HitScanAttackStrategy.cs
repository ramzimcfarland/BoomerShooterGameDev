//AI and forums/youtube videos
using UnityEngine;
public class HitScanAttackStrategy : IAttackStrategy
{
    private readonly float _range;
    private readonly float _damage;
    private readonly int _pelletCount;
    private readonly float _spreadAngle;
    private readonly LayerMask _hitMask;  

    public HitScanAttackStrategy(float range, float damage, LayerMask hitMask,
    int pelletCount, float spreadAngle)

    {
        _range = range;
        _damage = damage;
        _hitMask = hitMask;
        _spreadAngle = spreadAngle;
        _pelletCount = pelletCount;
    }
    public bool CanAttack() => true;

    public void Execute(WeaponCore weapon)
    {
        var origin = weapon.MuzzleTransform.position;
        var forward = weapon.MuzzleTransform.forward;
        
        for (int i = 0; i < _pelletCount; i++)
        {
            Vector3 direction = GetSpreadDirection(forward);

            if(Physics.Raycast(origin, direction, out RaycastHit hit, _range, _hitMask))
            {
                if (hit.collider.TryGetComponent<IDamageable>(out var target))
                {
                    target.TakeDamage(_damage);
                    Debug.Log("hit " + hit.collider.gameObject.name + "!");
                    Debug.DrawLine(origin, hit.point, Color.green, 2f);
                }
                else
                {
                 Debug.DrawLine(origin, origin + direction * _range, Color.red, 2f);   
                }
            }
            else
        {
            Debug.DrawLine(origin, origin + direction * _range, Color.red, 2f);
        }
        }
    }
    private Vector3 GetSpreadDirection(Vector3 forward)
    {
        if (_spreadAngle == 0f) return forward;
        float halfAngle = _spreadAngle * 0.5f;
        Vector3 randomInCone = new Vector3(
        UnityEngine.Random.Range(-halfAngle, halfAngle),
        UnityEngine.Random.Range(-halfAngle, halfAngle),
        0f);

        return Quaternion.Euler(randomInCone) * forward;
    }
}