using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public float jumpsAllowed = 2;
    private int jumpsRemaining = 0;   


    PlayerInput playerInput;
    Rigidbody2D rb;
    float gravityScaleAtStart;
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    void Update()
    {
        Movement();
        Jump();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = 0;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallLatch(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        WallLatch(false);
    }

    void Movement()
    {
        if (playerInput.actions["Move"].IsPressed())
        {
            Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
            //rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
            //to do: fix wall penetration
            transform.Translate(new Vector2(moveInput.x * moveSpeed * Time.deltaTime, 0));
        }
    }

    void Jump()
    {
        if (playerInput.actions["Jump"].WasPressedThisFrame())
        {
            if (jumpsRemaining < jumpsAllowed)
            {
                jumpsRemaining++;
                if (jumpsRemaining > 1)
                {
                    rb.linearVelocityY = 0;
                    //animacion doble salto
                }
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void WallLatch(bool latch)
    {
        if (latch)
        {
            rb.gravityScale = 0;
            rb.linearVelocityY = 0;
        }
        else
        {
            rb.gravityScale = 9.82f;
        }
    }
}
