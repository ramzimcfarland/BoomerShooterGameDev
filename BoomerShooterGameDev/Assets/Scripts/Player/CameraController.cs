//forums helped me to understand important things such as locking the x-rotation and what
//a "normal feeling" sensitivity would be
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
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //cannot look more than over your head or under your legs

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if(player != null)
        {
            player.Rotate(Vector3.up * look.x);
        }
    }
}
