using UnityEngine;
using UnityEngine.AI;

public class EnemyBirdAI : MonoBehaviour
{
    enum AIState
    {
        Idle,
        Chase
    }
    [SerializeField] private AIState currentState;
    NavMeshAgent agent;

    [SerializeField] private float chaseDistance;

    [SerializeField] private float suspiciousTime;
    private float timeSinceLastSawPlayer;

    private GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        timeSinceLastSawPlayer = suspiciousTime;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case AIState.Idle:

                if (distanceToPlayer <= chaseDistance)
                {
                    currentState = AIState.Chase;
                }
                break;

            case AIState.Chase:
                
                agent.SetDestination(player.transform.position);
                if (distanceToPlayer > chaseDistance)
                {
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;
                    timeSinceLastSawPlayer -= Time.deltaTime;

                    if (timeSinceLastSawPlayer <= 0)
                    {
                        currentState = AIState.Idle;
                        timeSinceLastSawPlayer = suspiciousTime;
                        agent.isStopped = false;
                    }
                }
                break;
        }
    }
}
