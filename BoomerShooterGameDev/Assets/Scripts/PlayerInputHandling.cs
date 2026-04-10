using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private CameraController cameraController;

    void OnLook(InputValue value)
    {
        cameraController.HandleLook(value.Get<Vector2>());
    }

    void OnFire(InputValue value)
    {
        if(value.isPressed && weapon != null)
        {
            weapon.Fire();
        }
    }
}
