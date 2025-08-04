using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage; // Для врага
    [SerializeField] private Slider _healthBarSlider; // Для игрока
    [SerializeField] private float maxHealth;

    private float currentHealth;
    private Camera _camera;

    public float CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        _camera = Camera.main;
    }

    public void UpdateHealthBar()
    {
        // Обновляем только тот компонент, который назначен
        if (_healthBarImage != null)
        {
            _healthBarImage.fillAmount = currentHealth / maxHealth;
        }

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
        // Если используется Image, поворачиваем его к камере
        if (_healthBarImage != null)
        {
            if (_camera == null)
            {
                _camera = Camera.main;
                if (_camera == null)
                    return;
            }

            transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}