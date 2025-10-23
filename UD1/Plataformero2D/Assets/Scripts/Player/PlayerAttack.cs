using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Player player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.enemyInRange = collision.GetComponent<Enemy>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.enemyInRange = null;
        }
    }
}
