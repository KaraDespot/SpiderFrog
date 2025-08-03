using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public GameObject timeOverPanel;
    public TextMeshProUGUI scoreText; // ��� ������ �����
    [SerializeField] FlySpawner flySpawner; // ������ �� ������� ���

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

            // ���������� ���� ��� ��������� �������
            if (scoreText != null && flySpawner != null)
                scoreText.text = "����: " + flySpawner.flyCount.ToString();
        }

        // ���������� UI ������� � �������� ��� (���� ����� � �������� �������)
        if (scoreText != null && flySpawner != null && !timeOverPanel.activeSelf)
            scoreText.text = "����: " + flySpawner.flyCount.ToString();
    }
}

    