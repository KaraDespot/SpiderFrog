using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private Camera _camera;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        _camera = Camera.main;
    }

    public void UpdateHealthBar()
    {
        _healthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath();
        }
        UpdateHealthBar();
    }

    void Update()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
            if (_camera == null)
                return;
        }
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}