using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Transform target1; // Первая цель (лягушка)
    [SerializeField] private Transform target2; // Вторая цель (паук)
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackCooldown = 1f;

    private Transform currentTarget;
    private float lastAttackTime;

    void Start()
    {
        // Выбираем ближайшую цель при старте
        currentTarget = GetClosestTarget();
    }

    void Update()
    {
        if (currentTarget == null) return; // Если цель уничтожена, ничего не делаем

        // Преследуем цель
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * 2f);

        OnAttack();
    }

    private Transform GetClosestTarget()
    {
        if (target1 == null && target2 == null) return null;
        if (target1 == null) return target2;
        if (target2 == null) return target1;

        float dist1 = Vector3.Distance(transform.position, target1.position);
        float dist2 = Vector3.Distance(transform.position, target2.position);
        return dist1 < dist2 ? target1 : target2;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void OnAttack()
    {
        // Атакуем, если в радиусе
        float distance = Vector3.Distance(transform.position, currentTarget.position);
        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            HealthBar healthBar = currentTarget.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }
}