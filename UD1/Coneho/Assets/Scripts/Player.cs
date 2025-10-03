using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class scrio : MonoBehaviour
{
    enum AnimTypeEnum
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Death = 3
    }
    SpriteRenderer spriteRenderer;
    AnimTypeEnum animState = AnimTypeEnum.Idle;
    Animator animator;
    public float speed = 10f;
    public float jumpForce = 20f;
    LayerMask groundLayer;
    LayerMask deathLayer;
    int jumps = 0;
    int maxJumps = 1;

    [SerializeField] float speedModifier = 1f;

    Rigidbody2D rb;
    Collider2D coll;

    Vector2 moveInput;
    bool jumpPressed;

    InputAction moveAction;
    InputAction jumpAction;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        moveAction = new InputAction(type: InputActionType.Value, binding: "<Keyboard>/a");
        moveAction.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d");
        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/space");
        moveAction.Enable();
        jumpAction.Enable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Defeat"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            animState = AnimTypeEnum.Death;
            spriteRenderer.color = Color.red;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }

    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        moveInput = new Vector2(moveAction.ReadValue<float>(), 0);
        jumpPressed = jumpAction.triggered;

        if (isGrounded())
        {
            jumps = 0;
        }

        if (jumps == maxJumps)
        {
            transform.Rotate(0, 0, spriteRenderer.flipX ? 10 : -10);
        }
        else
        { // te endereza al tocar el suelo
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }

        if (moveInput.x > 0f)
        {
            rb.linearVelocity = new Vector2(speed * speedModifier, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < -0f)
        {
            rb.linearVelocity = new Vector2(-speed * speedModifier, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
        }

        if (jumpPressed)
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
        if (!isGrounded())
        {
            animState = AnimTypeEnum.Jump;
        }
        else if (moveInput.x != 0)
        {
            animState = AnimTypeEnum.Run;
        }
        else
        {
            animState = AnimTypeEnum.Idle;
        }
        animator.SetInteger("state", (int)animState);
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
