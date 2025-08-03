using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button authorsButton;
    [SerializeField] private GameObject authorsPanel; // ������ "� ���"
    [SerializeField] private Button closeAuthorsButton; // ������ �������� ������

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
        closeAuthorsButton.onClick.AddListener(OnCloseAuthorsClicked);

        if (authorsPanel != null)
            authorsPanel.SetActive(false); // ������ ������ ��� ������
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