using UnityEngine;
using UnityEngine.InputSystem;

public class Coche : MonoBehaviour
{
    public float speed = 8f;
    public float rotation = 30f;
    PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInput.actions["Movimiento"].ReadValue<Vector2>();
        if (moveInput.y >= .5f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        if (moveInput.y <= -.5f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        if (moveInput.x >= .5f)
        {
            transform.Rotate(new Vector3(0, 0, -rotation * Time.deltaTime));
        }
        if (moveInput.x <= -.5f)
        {
            transform.Rotate(new Vector3(0, 0, rotation * Time.deltaTime));
        }
    }
}
