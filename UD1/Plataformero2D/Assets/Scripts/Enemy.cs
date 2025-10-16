using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 1f;

    void Start()
    {
    }

    void FixedUpdate()
    {
        Vector2 tipPosition = transform.position + transform.right * GetComponent<SpriteRenderer>().bounds.extents.x;
        RaycastHit2D hit = Physics2D.Raycast(tipPosition, Vector2.down, 1f);
        if (hit.collider == null)
            transform.Rotate(0, 180, 0);
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Player>().TakeDamage(contact.normal, 1);
        else
            transform.Rotate(0, 180, 0);

        Debug.DrawRay(contact.point, contact.normal, Color.green, 2f);
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
