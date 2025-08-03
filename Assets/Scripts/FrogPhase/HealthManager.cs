using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public int health = 3;
    public TextMeshProUGUI healthText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText; // Добавьте это поле
    [SerializeField] FlySpawner flySpawner;

    public int score = 0; // Добавьте это поле или получите счет из другого класса

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateHealthUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void TakeDamage()
    {
        health = Mathf.Max(health - 1, 0);
        UpdateHealthUI();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "x" + health.ToString();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (scoreText != null)
                scoreText.text = "Счет: " + flySpawner.flyCount.ToString(); // Показываем счет
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
