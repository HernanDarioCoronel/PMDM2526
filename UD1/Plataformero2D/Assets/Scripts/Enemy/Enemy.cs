using System.Collections;
using AnimEnums;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField]
    EnemyAudioController audioController;
    float timerMax = 2f;
    bool isWaiting = false;

    [Header("Patrol Points")]
    [SerializeField]
    GameObject pointA;

    [SerializeField]
    GameObject pointB;
    GameObject currentTarget;

    [Header("Movement Settings")]
    [SerializeField]
    float speed = 2f;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    [SerializeField]
    BasicEnemyAnimEnum currentAnim;

    [Header("Attack Settings")]
    CapsuleCollider2D attackTrigger;
    bool attacking = false;

    void Start()
    {
        currentTarget = pointA;
        currentAnim = BasicEnemyAnimEnum.Run;
        attackTrigger = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            Move();
        }

        animator.SetInteger("currAnim", (int)currentAnim);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    void Attack()
    {
        BasicEnemyAnimEnum previousAnim = currentAnim;

        currentAnim = BasicEnemyAnimEnum.Attack;
        isWaiting = true;
        attacking = true;

        StartCoroutine(PerformAttack(previousAnim));
    }

    IEnumerator PerformAttack(BasicEnemyAnimEnum previousAnim)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float attackDuration = stateInfo.length;

        yield return new WaitForSeconds(attackDuration);

        Collider2D hitPlayer = Physics2D.OverlapCapsule(
            attackTrigger.bounds.center,
            attackTrigger.bounds.size,
            attackTrigger.direction,
            0f,
            LayerMask.GetMask("Player")
        );

        if (hitPlayer != null)
        {
            Vector2 contactDirection = (
                hitPlayer.transform.position - transform.position
            ).normalized;
            audioController.PlayAttackSound();
            hitPlayer.GetComponent<Player>().TakeDamage(contactDirection * -1, 1);
        }
        else
        {
            audioController.PlayAttackMissSound();
        }

        currentAnim = previousAnim;
        attacking = false;
        isWaiting = previousAnim == BasicEnemyAnimEnum.Idle;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !attacking)
        {
            float distance = Vector2.Distance(transform.position, collision.transform.position);
            if (distance <= 1.0f)
            {
                Attack();
            }
        }
    }

    void Move()
    {
        currentAnim = BasicEnemyAnimEnum.Run;

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

        currentAnim = BasicEnemyAnimEnum.Idle;
        animator.SetInteger("currAnim", (int)currentAnim);

        yield return new WaitForSeconds(timerMax);

        currentAnim = BasicEnemyAnimEnum.Run;

        currentTarget = currentTarget == pointA ? pointB : pointA;

        isWaiting = false;
    }

    public void Kill()
    {
        audioController.PlayDeathSound();
        GetComponent<Explode2D>().Explode();
        Destroy(gameObject);
    }
}
