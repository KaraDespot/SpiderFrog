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
    }

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case AIState.ChaseFrog:
                if (targetFrog != null)
                {
                    agent.SetDestination(targetFrog.transform.position);
                }

                if (distanceToPlayer <= chaseDistance)
                {
                    currentState = AIState.ChaseSpider;
                }
                break;

            case AIState.ChaseSpider:
                agent.SetDestination(player.transform.position);

                if (distanceToPlayer <= attackDistance && Time.time >= lastAttackTime + attackCooldown)
                {
                    lastAttackTime = Time.time;
                }

                if (distanceToPlayer > chaseDistance)
                {
                    currentState = AIState.ChaseFrog;
                }
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
