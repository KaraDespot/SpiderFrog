using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    private void Awake()
    {
        // Здесь можно инициализировать другие менеджеры, если нужно
        SceneManager.LoadScene("MainMenu");
    }
}