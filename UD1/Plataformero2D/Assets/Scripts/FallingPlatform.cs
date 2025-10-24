using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    bool startedFalling = false;
    float shakeX = 0.1f;
    float shakeY = 0.1f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (startedFalling)
        {
            Shake();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !startedFalling)
        {
            startedFalling = true;
            StartCoroutine(PerformFalling());
        }
    }

    void Shake()
    {
        spriteRenderer.transform.localPosition = new Vector3(
            Mathf.Sin(Time.time * 50f) * 0.05f,
            Mathf.Sin(Time.time * 70f) * 0.05f,
            0f
        );
    }

    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 7f;
        startedFalling = false;

        spriteRenderer.transform.localPosition = Vector3.zero;

        //GetComponent<Explode2D>().Explode();
    }

    IEnumerator PerformFalling()
    {
        yield return new WaitForSeconds(10f);
        Fall();
        yield return new WaitForSeconds(1f); // wait for explosion effect
        Destroy(gameObject, 2f);
    }
}
