using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f;
    public float pauseDuration = 3f;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Vector3 nextPoint;

    void Start()
    {
        transform.position = pointA.transform.position;
        nextPoint = pointB.transform.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, nextPoint) < 0.1f)
        {
            if (nextPoint == pointA.transform.position)
            {
                nextPoint = pointB.transform.position;
            }
            else
            {
                nextPoint = pointA.transform.position;
            }
        }
        Invoke(nameof(PauseMovement), 0f);
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.fixedDeltaTime);
    }

    IEnumerator PauseMovement()
    {
        // to do: fix pause not working
        float originalSpeed = speed;
        speed = 0f;
        yield return new WaitForSeconds(pauseDuration);
        speed = originalSpeed;
    }
}
