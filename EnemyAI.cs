using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackRange = 1f;
    public float chaseRange = 7f;
    public int damage = 10;

    private float nextAttackTime = 0f;
    public float attackRate = 1f;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // مطاردة اللاعب إذا كان في النطاق
        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        // الهجوم إذا وصل للأساس
        else if (distanceToPlayer <= attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("العدو يهاجم اللاعب ويسبب ضرر: " + damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
