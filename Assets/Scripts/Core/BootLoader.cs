using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    [SerializeField] private GameManager _gameManagerPrefab;

    private void Awake()
    {
        // Инициализация GameManager, если его нет в сцене
        if (FindObjectOfType<GameManager>() == null && _gameManagerPrefab != null)
        {
            Instantiate(_gameManagerPrefab);
        }

        // Здесь можно инициализировать другие менеджеры, если нужно
        SceneManager.LoadScene("MainMenu");
    }
}