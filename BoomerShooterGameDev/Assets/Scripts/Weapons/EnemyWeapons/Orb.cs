//Projectiles handle their own damage functionality
using UnityEngine;

public class Orb : MonoBehaviour
{
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<IDamageable>(out var target))
            target.TakeDamage(_damage, DamageType.Ranged);
        Destroy(gameObject);
    }
}