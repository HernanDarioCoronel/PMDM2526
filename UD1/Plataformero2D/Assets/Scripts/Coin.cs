using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float minAngle = 10f;
    public float maxAngle = 80f;

    private bool rotatingForward = true;
    private float currentAngle;

    void Update()
    {
        currentAngle = transform.localEulerAngles.y;

        if (currentAngle > 180f)
            currentAngle -= 360f;

        if (rotatingForward && currentAngle >= maxAngle)
        {
            rotatingForward = false;
        }
        else if (!rotatingForward && currentAngle <= minAngle)
        {
            rotatingForward = true;
        }

        float direction = rotatingForward ? 1f : -1f;

        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().CollectCoin();
            Destroy(gameObject);
        }
    }
}
