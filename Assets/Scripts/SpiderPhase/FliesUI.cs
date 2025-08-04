using UnityEngine;
using TMPro;

public class FliesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fliesText;
    [SerializeField] private string displayFormat = "{0}";
    
    private void Start()
    {
        UpdateFliesDisplay();
    }
    
    private void Update()
    {
        UpdateFliesDisplay();
    }
    
    private void UpdateFliesDisplay()
    {
        if (fliesText != null && GameDataManager.Instance != null)
        {
            int flies = GameDataManager.Instance.GetFlies();
            fliesText.text = string.Format(displayFormat, flies);
        }
    }
    
    // Метод для использования мошки (можно вызывать из других скриптов для атаки)
    public bool UseFly()
    {
        if (GameDataManager.Instance != null)
        {
            int currentFlies = GameDataManager.Instance.GetFlies();
            if (currentFlies > 0)
            {
                GameDataManager.Instance.UseFly();
                UpdateFliesDisplay();
                return true;
            }
        }
        return false;
    }
    
    // Метод для получения количества мошек (для проверки перед атакой)
    public int GetFliesCount()
    {
        return GameDataManager.Instance != null ? GameDataManager.Instance.GetFlies() : 0;
    }
} 