using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public int health = 3;
    public TextMeshProUGUI healthText; // ���� ������ ����� "x3" �� UI

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
            // ����� ����� ������� ���������� ��� ����� ����� ����
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
