using UnityEngine;

public class SuperProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 50f;
    [SerializeField] private float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"SuperProjectile collided with {other.gameObject.name}");
        // Ищем HealthBar на объекте или его родителях
        HealthBar healthBar = other.GetComponent<HealthBar>();
        if (healthBar == null)
        {
            healthBar = other.GetComponentInParent<HealthBar>();
        }

        if (healthBar != null && other.CompareTag("Enemy"))
        {
            healthBar.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
