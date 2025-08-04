using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
        Debug.Log("GameOverManager Awake called");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
            Debug.Log("GameOverManager: gameOverPanel found and hidden");
        }
        else
        {
            Debug.LogWarning("GameOverManager: gameOverPanel is null!");
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOverManager.GameOver() called!");
        Time.timeScale = 0f;
        if (gameOverPanel != null)
        {
            Debug.Log("Activating gameOverPanel");
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverManager.GameOver(): gameOverPanel is null!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}