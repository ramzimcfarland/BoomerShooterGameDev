using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private WeaponCore _weapon;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private Health _health;

    private bool _isDead = false;

    private void Awake()
    {
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
}
