using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 120f;
    [SerializeField]
    private float accelerationRate = 5f;
    [SerializeField]
    private float brakeRate = 10f;
    [SerializeField]
    private float rotationSpeed = 250f;
    [SerializeField]
    private float currentSpeed = 0f;
    [SerializeField]
    private float targetSpeed = 0f;

    void Update()
    {

        if (Keyboard.current.wKey.isPressed)
        {
            targetSpeed = maxSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            targetSpeed = 0f;
        }
        else
        {
            targetSpeed = 0f;
        }


        float rate = (targetSpeed > currentSpeed) ? accelerationRate : brakeRate;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.deltaTime);

        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}
