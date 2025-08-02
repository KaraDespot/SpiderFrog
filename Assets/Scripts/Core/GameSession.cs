using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Header("Runtime Data")]
    [SerializeField] private RuntimeDataSO _runtimeData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // ���� �� ��������� ����� ���������, ������� ��������� �� Resources
        if (_runtimeData == null)
        {
            _runtimeData = Resources.Load<RuntimeDataSO>("RuntimeDataSO");
            if (_runtimeData == null)
            {
                Debug.LogWarning("RuntimeDataSO �� ������ � Resources � �� �������� ����� ���������.");
            }
        }
    }

    public RuntimeDataSO RuntimeData => _runtimeData;
}