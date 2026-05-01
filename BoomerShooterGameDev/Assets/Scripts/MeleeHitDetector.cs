using UnityEngine;

public class MeleeHitDetector : MonoBehaviour
{
    [SerializeField] private WeaponCore _weapon;
    private bool _isActive = false;
    public void EnableHit()
        {
        Debug.Log("Enabled collision");
        _isActive = true;
        }
    public void DisableHit() => _isActive = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!_isActive) return;
        
        if(collision.TryGetComponent<IDamageable>(out var target))
        {
            Debug.Log("Target collided with");
            target.TakeDamage(_weapon.Damage);
        }
    }

}
