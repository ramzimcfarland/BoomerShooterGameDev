using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private WeaponCore _weapon;
    [SerializeField] private CameraController _cameraController;

    void OnLook(InputValue value)
    {
        _cameraController.HandleLook(value.Get<Vector2>());
    }

    void OnFire(InputValue value)
    {
        if(value.isPressed && _weapon != null)
        {
            _weapon.TryFire();
        }
    }
}
