using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = .1f;
    private float xRotation = 0f;
[SerializeField] private Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleLook(Vector2 lookInput)
    {
        Vector2 look = lookInput * sensitivity;

        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if(player != null)
        {
            player.Rotate(Vector3.up * look.x);
        }
    }
}
