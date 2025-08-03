using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button authorsButton;

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
    }

    private void OnStartClicked()
    {
        // Переход через загрузочный экран
        _sceneLoader.LoadScene("LoadingScene");
        // В LoadingScene должен быть SceneLoader, который загрузит gameSceneName
        PlayerPrefs.SetString("NextScene", gameSceneName);
    }

    private void OnAuthorsClicked()
    {
        _sceneLoader.LoadScene("LoadingScene");
        PlayerPrefs.SetString("NextScene", authorsSceneName);
    }
}