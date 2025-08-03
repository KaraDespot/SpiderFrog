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
    [SerializeField] private float suspiciousTime;
    private float timeSinceLastSawPlayer;

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

        timeSinceLastSawPlayer = suspiciousTime;
    }

    void Update()
    {
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
                

                if (distanceToPlayer > chaseDistance)
                {
                    timeSinceLastSawPlayer -= Time.deltaTime;

                    if (timeSinceLastSawPlayer <= 0)
                    {
                        currentState = AIState.ChaseFrog;
                        timeSinceLastSawPlayer = suspiciousTime;
                    }
                }
                else
                {
                     timeSinceLastSawPlayer = suspiciousTime;
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
