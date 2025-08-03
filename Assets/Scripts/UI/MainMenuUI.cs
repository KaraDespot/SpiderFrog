using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button authorsButton;
    [SerializeField] private GameObject authorsPanel; // Панель "О нас"
    [SerializeField] private Button closeAuthorsButton; // Кнопка закрытия панели

    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string authorsSceneName = "AuthorsScene";

    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        if (_sceneLoader == null)
            Debug.LogError("SceneLoader не найден на сцене MainMenu!");

        startButton.onClick.AddListener(OnStartClicked);
        authorsButton.onClick.AddListener(OnAuthorsClicked);
        closeAuthorsButton.onClick.AddListener(OnCloseAuthorsClicked);

        if (authorsPanel != null)
            authorsPanel.SetActive(false); // Скрыть панель при старте
    }

    private void OnStartClicked()
    {
        _sceneLoader.LoadScene("LoadingScene");
        PlayerPrefs.SetString("NextScene", gameSceneName);
    }

    private void OnAuthorsClicked()
    {
        if (authorsPanel != null)
            authorsPanel.SetActive(true);
    }

    private void OnCloseAuthorsClicked()
    {
        if (authorsPanel != null)
            authorsPanel.SetActive(false);
    }
}