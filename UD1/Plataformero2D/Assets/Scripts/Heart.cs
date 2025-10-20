using UnityEngine;

public class Heart : MonoBehaviour
{
    float timer = 0f;
    bool isShrinking = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            if (!isShrinking)
            {
                transform.localScale += Vector3.one * 0.1f;
            }
            else
            {
                transform.localScale -= Vector3.one * 0.1f;
            }
            isShrinking = !isShrinking;
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Heal();
            Destroy(gameObject);
        }
    }
}
