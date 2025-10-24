using System.Collections;
using AnimEnums;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Audio Settings")]
    public PlayerAudioController audioController;

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

    public bool justLatched = false;

    PlayerInput playerInput;
    Rigidbody2D rb;

    [SerializeField]
    float gravityScaleAtStart;
    public int jumpsRemaining = 0;
    bool isKnockedBack = false;
    float knockbackTimer = 0.6f;
    float knockbackTimerReset = 0.6f;

    [Header("Stats Settings")]
    [SerializeField]
    PlayerStats playerStats;
    int pointsLostPerSecond = 50;
    float timer = 0f;
    public HeartsBarController heartsBarController;

    [SerializeField]
    Animator animator;
    PlayerAnimEnum currentAnim = PlayerAnimEnum.Idle;

    public Enemy enemyInRange;

    bool isJumping = false;
    bool isAttacking = false;
    bool isGrounded = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        trueJumpForce *= jumpForceInTiles;
        gravityScaleAtStart = rb.gravityScale;
    }

    void FixedUpdate()
    {
        if (isAttacking)
        {
            Attack();
            return;
        }
        if (!isKnockedBack)
        {
            Movement();
            if (isJumping)
            {
                Jump();
                isJumping = false;
            }
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

        if (!isGrounded && rb.linearVelocity.y < -0.1f && currentAnim != PlayerAnimEnum.Fall)
        {
            currentAnim = PlayerAnimEnum.Fall;
        }
    }

    void Update()
    {
        PointsLostOverTime();

        if (playerInput.actions["Jump"].WasPressedThisFrame())
        {
            if (isGrounded || jumpsRemaining < jumpsAllowed)
                isJumping = true;
        }

        if (playerInput.actions["Attack"].WasPressedThisFrame())
        {
            isAttacking = true;
        }

        animator.SetInteger("currAnim", (int)currentAnim);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            currentAnim = PlayerAnimEnum.Idle;
            frictionMaterial.friction = 0.4f;
            justLatched = false;
            jumpsRemaining = 0;
        }

        WallLatch(collision.gameObject.CompareTag("Wall") && !justLatched);

        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            currentAnim = PlayerAnimEnum.Fall;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            currentAnim = PlayerAnimEnum.Fall;
            WallLatch(false);
        }
    }

    void Movement()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        // Only switch to run/idle when grounded and not attacking
        if (isGrounded && !isAttacking)
        {
            currentAnim = moveInput.x != 0 ? PlayerAnimEnum.Run : PlayerAnimEnum.Idle;
        }

        if (moveInput.x < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else if (moveInput.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (jumpsRemaining < jumpsAllowed)
        {
            audioController.PlayJumpSound();
            jumpsRemaining++;
            currentAnim = PlayerAnimEnum.Jump;
            isGrounded = false;

            if (rb.linearVelocity.y < 0)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            rb.AddForce(Vector2.up * trueJumpForce, ForceMode2D.Impulse);

            StartCoroutine(WaitForGrounded());
        }
    }

    IEnumerator WaitForGrounded()
    {
        yield return new WaitUntil(() => isGrounded);
        isJumping = false;
        audioController.PlayLandSound();
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
            currentAnim = PlayerAnimEnum.WallLatch;
            audioController.PlayLatchSound();
        }
        else
        {
            rb.gravityScale = gravityScaleAtStart;
        }
    }

    public void TakeDamage(Vector2 contact, int damage)
    {
        heartsBarController.TakeDamage(damage);
        audioController.PlayHurtSound();
        if (playerStats.Health <= 0)
        {
            Die();
            return;
        }

        Vector2 finalForce =
            new Vector2(-contact.normalized.x * pushAmount * 2f, trueJumpForce) / 2f;
        Vector2 getPushed = finalForce;
        rb.AddForce(getPushed, ForceMode2D.Impulse);
        isKnockedBack = true;
        currentAnim = PlayerAnimEnum.TakeHit;
    }

    public void CollectCoin()
    {
        playerStats.AddPoints(250);
    }

    public void Heal()
    {
        if (playerStats.Health < playerStats.MaxHealth)
            heartsBarController.Heal(1);
        else
            playerStats.AddPoints(500);

        audioController.PlayHealthPickupSound();
    }

    public void Attack()
    {
        currentAnim = PlayerAnimEnum.Attack;
        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(0.2f);

        if (enemyInRange != null)
            enemyInRange.Kill();

        isAttacking = false;
        yield return new WaitForSeconds(0.05f);
    }

    void Die()
    {
        rb.linearVelocity = Vector2.zero;
        this.enabled = false;
        audioController.PlayDeathSound();
        currentAnim = PlayerAnimEnum.Death;
        StartCoroutine(getKilled());
    }

    IEnumerator getKilled()
    {
        animator.SetInteger("currAnim", (int)currentAnim);
        yield return new WaitForSeconds(1.2f);
        animator.speed = 0f;
        GetComponent<Explode2D>().Explode();
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        RestartLevel();
    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
