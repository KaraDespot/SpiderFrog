    using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage; // Для врага используем Image
    [SerializeField] private Slider _healthBarSlider; // Для игрока используем Slider
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
        // Если есть Image, обновляем fillAmount (для врага)
        if (_healthBarImage != null)
        {
            _healthBarImage.fillAmount = currentHealth / maxHealth;
        }
        // Если есть Slider, обновляем value (для игрока)
        if (_healthBarSlider != null)
        {
            _healthBarSlider.maxValue = maxHealth;
            _healthBarSlider.value = currentHealth;
        }
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