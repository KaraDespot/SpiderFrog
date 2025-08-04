using UnityEngine;
using UnityEngine.AI;

public class EnemyBirdAI : MonoBehaviour
{
    enum AIState
    {
        ChaseFrog,
        ChaseSpider
    }
    [SerializeField] private AIState currentState;
    NavMeshAgent agent;

    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackDamage = 10f; // Добавляем урон атаки
    private float lastAttackTime;

    private GameObject player;
    [SerializeField] private GameObject targetFrog;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (targetFrog == null)
        {
            targetFrog = GameObject.FindGameObjectWithTag("Frog");
        }

        // Отладочная информация
        Debug.Log($"EnemyBirdAI Start: Player found = {player != null}, Frog found = {targetFrog != null}");
        if (player != null)
            Debug.Log($"Player tag: {player.tag}, name: {player.name}");
        if (targetFrog != null)
            Debug.Log($"Frog tag: {targetFrog.tag}, name: {targetFrog.name}");
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is null in EnemyBirdAI Update");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case AIState.ChaseFrog:
                if (targetFrog != null)
                {
                    agent.SetDestination(targetFrog.transform.position);
                    
                    // Проверяем, можем ли атаковать лягушку
                    float distanceToFrog = Vector3.Distance(transform.position, targetFrog.transform.position);
                    if (distanceToFrog <= attackDistance && Time.time >= lastAttackTime + attackCooldown)
                    {
                        Debug.Log($"Attacking Frog! Distance: {distanceToFrog}, AttackDistance: {attackDistance}");
                        AttackTarget(targetFrog);
                    }
                }

                if (distanceToPlayer <= chaseDistance)
                {
                    currentState = AIState.ChaseSpider;
                    Debug.Log("Switching to ChaseSpider state");
                }
                break;

            case AIState.ChaseSpider:
                agent.SetDestination(player.transform.position);

                if (distanceToPlayer <= attackDistance && Time.time >= lastAttackTime + attackCooldown)
                {
                    Debug.Log($"Attacking Player! Distance: {distanceToPlayer}, AttackDistance: {attackDistance}");
                    AttackTarget(player);
                }

                if (distanceToPlayer > chaseDistance)
                {
                    currentState = AIState.ChaseFrog;
                    Debug.Log("Switching to ChaseFrog state");
                }
                break;
        }
    }

    // Новый метод для атаки цели
    private void AttackTarget(GameObject target)
    {
        if (target == null) 
        {
            Debug.LogWarning("AttackTarget: target is null");
            return;
        }

        Debug.Log($"AttackTarget called on: {target.name} with tag: {target.tag}");
        
        HealthBar healthBar = target.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            Debug.Log($"HealthBar found! Current health: {healthBar.CurrentHealth}");
            if (healthBar.CurrentHealth > 0)
            {
                healthBar.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
                Debug.Log($"Damage dealt: {attackDamage}, New health: {healthBar.CurrentHealth}");
            }
            else
            {
                Debug.Log("Target already dead (health <= 0)");
            }
        }
        else
        {
            Debug.LogWarning($"HealthBar component not found on {target.name}");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
