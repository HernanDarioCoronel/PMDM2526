using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    PhysicsMaterial2D frictionMaterial;

    [SerializeField]
    float jumpForceInTiles = 2f;

    public float trueJumpForce = 10f;

    [SerializeField]
    int jumpsAllowed = 2;

    [SerializeField]
    float pushAmount = 5f;

    bool justLatched = false;

    [Header("Grappling Settings")]
    [SerializeField]
    float grappleMaxRange = 10f;

    [SerializeField]
    float grappleSwingForce = 15f;
    PlayerInput playerInput;
    Rigidbody2D rb;

    [SerializeField]
    float gravityScaleAtStart;
    Collider2D currentGrapplePoint;
    DistanceJoint2D grappleJoint;
    LineRenderer grappleLine;
    bool isGrappling = false;
    public int jumpsRemaining = 0;
    bool isKnockedBack = false;
    float knockbackTimer = 0.6f;
    float knockbackTimerReset = 0.6f;

    [Header("Stats Settings")]
    [SerializeField]
    PlayerStats playerStats;
    int pointsLostPerSecond = 50;
    float timer = 0f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody2D>();

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
        playerStats.ResetScore();
        playerStats.ResetHealth();
        trueJumpForce *= jumpForceInTiles;
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
                knockbackTimer = knockbackTimerReset;
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
        PointsLostOverTime();
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
            if (collision.contacts[0].normal.y > 0.5f)
                frictionMaterial.friction = 0f;
            else
            {
                frictionMaterial.friction = 0.4f;
                justLatched = false;
            }

            jumpsRemaining = 0;
        }

        WallLatch(collision.gameObject.CompareTag("Wall") && !justLatched);

        if (collision.gameObject.CompareTag("Death"))
        {
            playerStats.ApplyDamage(playerStats.MaxHealth);
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
            rb.AddForce(Vector2.up * trueJumpForce, ForceMode2D.Impulse);
        }
    }

    void PointsLostOverTime()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerStats.SubtractPoints(pointsLostPerSecond);
            timer = 0f;

            if (playerStats.Score < 0)
                playerStats.ResetScore();
        }
    }

    void WallLatch(bool latch)
    {
        if (latch)
        {
            justLatched = true;
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            jumpsRemaining--;
        }
        else
        {
            rb.gravityScale = gravityScaleAtStart;
        }
    }

    public void TakeDamage(Vector2 contact, int damage)
    {
        playerStats.ApplyDamage(damage);
        if (playerStats.Health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }

        Vector2 finalForce =
            new Vector2(-contact.normalized.x * pushAmount * 2f, trueJumpForce) / 2f;
        Vector2 getPushed = finalForce;
        rb.AddForce(getPushed, ForceMode2D.Impulse);
        isKnockedBack = true;
    }

    public void CollectCoin()
    {
        playerStats.AddPoints(250);
    }

    public void Heal()
    {
        if (playerStats.Health < playerStats.MaxHealth)
            playerStats.Heal(1);
        else
            playerStats.AddPoints(500);
    }
}
