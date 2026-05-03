using UnityEngine;

public class MeleeHitDetector : MonoBehaviour
{
    [SerializeField] private WeaponCore _weapon;
    private bool _isActive = false;
    public void EnableHit() => _isActive = true;
    public void DisableHit() => _isActive = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!_isActive) return;
        
        if(collision.TryGetComponent<IDamageable>(out var target))
        {
            target.TakeDamage(_weapon.Damage, DamageType.Melee);
        }
    }

}
