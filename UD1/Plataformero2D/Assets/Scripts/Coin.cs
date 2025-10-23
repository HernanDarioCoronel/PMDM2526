using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    Collider2D col;

    [SerializeField]
    AudioClip coinPickupClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(getPickedUp());
        }
    }

    IEnumerator getPickedUp()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;
        audioSource.PlayOneShot(coinPickupClip);
        yield return new WaitForSeconds(coinPickupClip.length);
        Destroy(gameObject);
    }
}
