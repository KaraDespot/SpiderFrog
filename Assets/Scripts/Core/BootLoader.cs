using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    [SerializeField] private GameManager _gameManagerPrefab;

    private void Awake()
    {
        // ������������� GameManager, ���� ��� ��� � �����
        if (FindObjectOfType<GameManager>() == null && _gameManagerPrefab != null)
        {
            Instantiate(_gameManagerPrefab);
        }

        // ����� ����� ���������������� ������ ���������, ���� �����
        SceneManager.LoadScene("MainMenu");
    }
}