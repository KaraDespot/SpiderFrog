using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform target1; // Лягушка
    [SerializeField] private Transform target2; // Паук
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackCooldown = 1f;

    private float lastAttackTime;

    void Update()
    {
        TryAttackTarget(target1);
        TryAttackTarget(target2);
    }

    private void TryAttackTarget(Transform target)
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            HealthBar healthBar = target.GetComponent<HealthBar>();
            if (healthBar != null && healthBar.CurrentHealth > 0)
            {
                healthBar.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}