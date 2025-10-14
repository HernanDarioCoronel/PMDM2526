using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public int jumpsAllowed = 2;
    public bool impulse = true;

    [Header("Grappling Settings")]
    public float grappleMaxRange = 10f;
    public float grappleSwingForce = 15f;

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private float gravityScaleAtStart;
    private Collider2D currentGrapplePoint;
    private DistanceJoint2D grappleJoint;
    private LineRenderer grappleLine;

    private bool isGrappling = false;
    private int jumpsRemaining = 0;
    private bool isKnockedBack = false;
    private float knockbackTime = 0.3f;
    private float knockbackTimer = 0f;

    [Header("Health Settings")]
    public int health = 3;
    public int maxHealth = 3;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = rb.gravityScale;

        grappleJoint = GetComponent<DistanceJoint2D>();
        grappleJoint.enabled = false;
        grappleJoint.autoConfigureDistance = false;
        grappleJoint.autoConfigureConnectedAnchor = false;

        grappleLine = GetComponent<LineRenderer>();
        grappleLine.enabled = false;
        grappleLine.startWidth = 0.05f;
        grappleLine.endWidth = 0.05f;
        grappleLine.startColor = Color.green;
        grappleLine.endColor = Color.green;
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            Movement();
        }
        else
        {
            knockbackTimer -= Time.fixedDeltaTime;
            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
            }
        }

        if (isGrappling)
        {
            Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
            rb.AddForce(Vector2.right * moveInput.x * grappleSwingForce);
        }
    }

    void Update()
    {
        // Saltar
        if (playerInput.actions["Jump"].WasPressedThisFrame())
        {
            Jump();
            GrapplingSystem.StopGrapple(grappleJoint, grappleLine);
            isGrappling = false;
        }

        // Grappling
        if (playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (!isGrappling)
            {
                rb.gravityScale = gravityScaleAtStart * 2;
                isGrappling = GrapplingSystem.StartGrapple(
                    rb,
                    grappleJoint,
                    grappleLine,
                    transform,
                    currentGrapplePoint,
                    grappleMaxRange
                );
            }
            else
            {
                rb.gravityScale = gravityScaleAtStart;
                GrapplingSystem.StopGrapple(grappleJoint, grappleLine);
                isGrappling = false;
            }
        }

        // Dibuja la cuerda
        GrapplingSystem.DrawGrappleLine(grappleLine, transform, currentGrapplePoint);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrapplePoint"))
            currentGrapplePoint = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentGrapplePoint)
            currentGrapplePoint = null;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        WallLatch(false);
    }

    void Movement()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (jumpsRemaining < jumpsAllowed)
        {
            jumpsRemaining++;
            if (jumpsRemaining > 1)
            {
                if (rb.linearVelocity.y < 0)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                }
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                // animación doble salto
            }
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void WallLatch(bool latch)
    {
        if (latch)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        else
        {
            rb.gravityScale = gravityScaleAtStart;
        }
    }

    public void TakeDamage(Vector2 contact, int damage)
    {
        Vector2 ouchie = new Vector2(5, 5);
        rb.AddForce(ouchie, ForceMode2D.Impulse);
        isKnockedBack = true;
    }
}
