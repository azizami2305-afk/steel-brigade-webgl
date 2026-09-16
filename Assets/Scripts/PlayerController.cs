using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;

    Rigidbody rb;
    bool isGrounded;
    WeaponSystem weaponSystem;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        weaponSystem = GetComponent<WeaponSystem>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    void Update()
    {
        float h = InputHandler.GetHorizontal();

        Vector3 vel = rb.velocity;
        vel.x = h * moveSpeed;
        rb.velocity = vel;

        UpdateGrounded();

        if (InputHandler.JumpPressed() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        if (InputHandler.FirePressed())
        {
            weaponSystem?.Fire();
        }

        // Simple crouch (scale) for prototype
        if (InputHandler.CrouchHeld())
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 0.6f, 1f), Time.deltaTime * 10f);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10f);
        }
    }

    void UpdateGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance + 0.01f);
    }
}
