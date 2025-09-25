using UnityEngine;
using UnityEngine.InputSystem;

public class scrio : MonoBehaviour
{
    float speed = 12f;
    float jumpForce = 30f;
    LayerMask groundLayer;
    int jumps = 0;
    int maxJumps = 1;

    [SerializeField] float speedModifier = 1f;

    Rigidbody2D rb;
    Collider2D coll;

    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (isGrounded())
        {
            jumps = 0;
        }

        if (jumps == maxJumps)
        {
            transform.Rotate(0, 0, -10);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }

        if (keyboard.dKey.isPressed)
        {
            rb.linearVelocity = new Vector2(speed * speedModifier, rb.linearVelocity.y);
            if (transform.rotation.eulerAngles.y != 0)
                transform.Rotate(0, -180, 0);
        }
        if (keyboard.aKey.isPressed)
        {
            rb.linearVelocity = new Vector2(-speed * speedModifier, rb.linearVelocity.y);
            if (transform.rotation.eulerAngles.y != 180)
                transform.Rotate(0, 180, 0);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isGrounded())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumps++;
            }
            else if (jumps < maxJumps)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumps++;
            }
        }

    }


    bool isGrounded() => Physics2D.BoxCast(
        coll.bounds.center,
        coll.bounds.size,
        0f,
        Vector2.down,
        0.1f,
        groundLayer
    );
}
