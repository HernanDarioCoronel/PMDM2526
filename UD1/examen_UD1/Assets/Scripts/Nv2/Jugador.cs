using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rb;
    CapsuleCollider2D coll;

    [SerializeField]
    private LayerMask jumpableGround;

    public float jumpForce = 15f;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        jumpableGround = LayerMask.GetMask("Ground");
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInput.actions["Movimiento"].ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * speed * Time.deltaTime, 0);

        bool jumped = playerInput.actions["Salto"].ReadValue<float>() > 0f;

        if (jumped && isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }



    private bool isGrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround
        );
    }
}
