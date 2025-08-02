using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Header("Runtime Data")]
    [SerializeField] private RuntimeDataSO _runtimeData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Если не назначено через инспектор, пробуем загрузить из Resources
        if (_runtimeData == null)
        {
            _runtimeData = Resources.Load<RuntimeDataSO>("RuntimeDataSO");
            if (_runtimeData == null)
            {
                Debug.LogWarning("RuntimeDataSO не найден в Resources и не назначен через инспектор.");
            }
        }
    }

    public RuntimeDataSO RuntimeData => _runtimeData;
}