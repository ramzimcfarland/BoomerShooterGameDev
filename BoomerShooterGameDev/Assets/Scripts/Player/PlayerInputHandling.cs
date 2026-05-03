using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private WeaponCore _weapon;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private Health _health;
    [SerializeField] private WeaponCore _sword;
    [SerializeField] private WeaponCore _shotgun;

    private bool _isDead = false;

    private void Awake()
    {
        _weapon = _sword;
        _weapon.Equip();
        _health.OnDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        _isDead = true;
    }

    private void OnDestroy()
    {
        _health.OnDeath -= OnPlayerDeath;
    }

    void OnLook(InputValue value)
    {
        if (GameState.IsGamePaused()) return; 
        if (_isDead) return;
        _cameraController.HandleLook(value.Get<Vector2>());
    }

    void OnFire(InputValue value)
    {
        if (GameState.IsGamePaused()) return;
        if (_isDead) return;
        if(value.isPressed && _weapon != null)
        {
            _weapon.TryFire();
        }
    }
    void OnReload(InputValue value)
    {
        if(value.isPressed && _weapon != null && _weapon is RangedWeaponCore ranged)
        {
            ranged.TryReload();
        }
    }
    void OnEquip1(InputValue value)
    {
        if (value.isPressed)
        {
            _weapon.Unequip();
            _weapon = _sword;
            _weapon.Equip();
        }
    }
        void OnEquip2(InputValue value)
    {
        if (value.isPressed)
        {
            _weapon.Unequip();
            _weapon = _shotgun;
            _weapon.Equip();
        }
    }
}
