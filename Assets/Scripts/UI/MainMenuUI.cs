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
            Debug.LogError("SceneLoader �� ������ �� ����� MainMenu!");

        startButton.onClick.AddListener(OnStartClicked);
        authorsButton.onClick.AddListener(OnAuthorsClicked);
    }

    private void OnStartClicked()
    {
        // ������� ����� ����������� �����
        _sceneLoader.LoadScene("LoadingScene");
        // � LoadingScene ������ ���� SceneLoader, ������� �������� gameSceneName
        PlayerPrefs.SetString("NextScene", gameSceneName);
    }

    private void OnAuthorsClicked()
    {
        _sceneLoader.LoadScene("LoadingScene");
        PlayerPrefs.SetString("NextScene", authorsSceneName);
    }
}