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
        Debug.Log($"HealthBar TakeDamage called on {gameObject.name}. Current health: {currentHealth}, Damage: {damage}");
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log($"Health reached 0, calling OnDeath on {gameObject.name}");
            OnDeath();
        }
        UpdateHealthBar();
        Debug.Log($"HealthBar updated. New health: {currentHealth}");
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
        }
    }

    public void OnDeath()
    {
        Debug.Log($"OnDeath called on {gameObject.name} with tag: {gameObject.tag}");
        // Если это игрок или лягушка, вызываем GameOver
        if (CompareTag("Player") || CompareTag("Frog"))
        {
            Debug.Log($"Calling GameOver for {gameObject.name}");
            if (GameOverManager.Instance != null)
            {
                Debug.Log("GameOverManager.Instance found, calling GameOver()");
                GameOverManager.Instance.GameOver();
            }
            else
            {
                Debug.LogError("GameOverManager.Instance is null! GameOverManager not found in scene.");
            }
        }
        else
        {
            Debug.Log($"Not calling GameOver for {gameObject.name} (tag: {gameObject.tag})");
        }
        
        // Не уничтожаем объект сразу, чтобы GameOver успел сработать
        // Destroy(gameObject);
    }
}