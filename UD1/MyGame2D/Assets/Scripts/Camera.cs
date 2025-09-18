using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D carRb;
    public float baseDistance = -10f; // default z offset
    public float maxExtraDistance = -5f;
    public float speedFactor = 0.05f;

    void LateUpdate()
    {
        float speed = carRb.linearVelocity.magnitude;

        float zOffset = Mathf.Lerp(baseDistance, baseDistance + maxExtraDistance, speed * speedFactor);

        Vector3 newPos = new Vector3(target.position.x, target.position.y, zOffset);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 5f);
    }
}
