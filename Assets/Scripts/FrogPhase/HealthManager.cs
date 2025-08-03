using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public int health = 3;
    public TextMeshProUGUI healthText; // сюда вставь текст "x3" из UI

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage()
    {
        health = Mathf.Max(health - 1, 0);
        UpdateHealthUI();

        if (health <= 0)
        {
            Debug.Log("Game Over!");
            // Здесь можно сделать перезапуск или сцену конца игры
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "x" + health.ToString();
        }
    }
}
