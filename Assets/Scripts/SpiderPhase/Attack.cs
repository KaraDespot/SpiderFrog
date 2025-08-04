using UnityEngine;

public class Attack : MonoBehaviour, IAttack
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask targetLayer;

    public void OnAttack()
    {
        Collider[] hitTargets = Physics.OverlapSphere(transform.position, attackRange, targetLayer);

        foreach (Collider target in hitTargets)
        {
            HealthBar healthBar = target.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
