//Made using guides/youtube videos/forums
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 9f;
    public float jumpPower = 2f;
    public float gravity = -15f;
    private Vector3 velocity; 
    private CharacterController cc;

    private Vector2 moveInput;
    private bool jumpPressed;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (value.isPressed && cc.isGrounded)
        {
            jumpPressed = true;
        }
    }

    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        cc.Move(Time.deltaTime * speed * move);

        if (cc.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        if (jumpPressed)
            {
                velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
                jumpPressed = false;
            }
        
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
