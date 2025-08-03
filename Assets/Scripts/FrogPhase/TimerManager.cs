using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public GameObject timeOverPanel;
    public TextMeshProUGUI scoreText; // Для вывода счета
    [SerializeField] FlySpawner flySpawner; // Ссылка на спавнер мух

    private float currentTime;
    public float startTime = 30f;

    void Start()
    {
        currentTime = startTime;
        timeOverPanel.SetActive(false);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0f;
            timeOverPanel.SetActive(true);

            // Показываем счет при окончании времени
            if (scoreText != null && flySpawner != null)
                scoreText.text = "Счет: " + flySpawner.flyCount.ToString();
        }

        // Обновление UI таймера и счетчика мух (если нужно в реальном времени)
        if (scoreText != null && flySpawner != null && !timeOverPanel.activeSelf)
            scoreText.text = "Счет: " + flySpawner.flyCount.ToString();
    }
}

    