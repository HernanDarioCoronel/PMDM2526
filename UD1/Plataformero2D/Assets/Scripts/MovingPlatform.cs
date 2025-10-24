using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool isWaiting = false;
    float timerMax = 2f;

    [SerializeField]
    GameObject pointA;

    [SerializeField]
    GameObject pointB;
    GameObject currentTarget;

    [SerializeField]
    float speed = 2f;

    void Start()
    {
        currentTarget = pointA;
    }

    void Update()
    {
        if (!isWaiting)
            Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remove player from platform
            collision.transform.SetParent(null);
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentTarget.transform.position,
            speed * Time.deltaTime
        );

        if (
            Vector2.Distance(transform.position, currentTarget.transform.position) < 0.1f
            && !isWaiting
        )
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180f, 0);
            StartCoroutine(PauseAtPoint());
        }
    }

    IEnumerator PauseAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(timerMax);
        currentTarget = currentTarget == pointA ? pointB : pointA;
        isWaiting = false;
    }
}
