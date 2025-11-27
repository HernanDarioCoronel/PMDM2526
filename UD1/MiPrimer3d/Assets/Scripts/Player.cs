using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public float lookSensitivity = 200f;
    PlayerInput playerInput;
    Rigidbody rb;
    bool isGrounded = true;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (playerInput.actions["Move"].IsPressed())
        {
            Vector3 moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y);
            rb.transform.Translate(movement * Time.fixedDeltaTime * speed);
        }
        if (playerInput.actions["Jump"].IsPressed() && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        Vector2 look = playerInput.actions["Look"].ReadValue<Vector2>();

        transform.Rotate(Vector3.up, look.x * lookSensitivity * Time.fixedDeltaTime);
        // to do: fix camera twisting issue
        Camera cam = Camera.main;
        if (cam != null)
        {
            Transform camT = cam.transform;

            float currentPitch = camT.localEulerAngles.x;
            if (currentPitch > 180f) currentPitch -= 360f;
            float newPitch = currentPitch - look.y * lookSensitivity * Time.fixedDeltaTime;
            newPitch = Mathf.Clamp(newPitch, -80f, 80f);
            camT.localEulerAngles = new Vector3(newPitch, camT.localEulerAngles.y, camT.localEulerAngles.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
    }
}
