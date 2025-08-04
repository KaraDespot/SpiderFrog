using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private RuntimeDataSO runtimeData;
    
    public static GameDataManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SaveFlies(int flyCount)
    {
        if (runtimeData != null)
        {
            runtimeData.collectedFlies = flyCount;
            Debug.Log($"Сохранено мошек: {flyCount}");
        }
    }
    
    public int GetFlies()
    {
        return runtimeData != null ? runtimeData.collectedFlies : 0;
    }
    
    public void UseFly()
    {
        if (runtimeData != null && runtimeData.collectedFlies > 0)
        {
            runtimeData.collectedFlies--;
            Debug.Log($"Использована мошка. Осталось: {runtimeData.collectedFlies}");
        }
    }
} 