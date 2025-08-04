using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanelHandler : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private FlySpawner flySpawner; // Ссылка на FlySpawner для получения количества мошек

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueClicked);
        
        // Если FlySpawner не назначен, попробуем найти его автоматически
        if (flySpawner == null)
        {
            flySpawner = FindObjectOfType<FlySpawner>();
        }
    }

    private void OnContinueClicked()
    {
        // Сохраняем мошки перед переходом на следующую сцену
        if (flySpawner != null)
        {
            flySpawner.SaveFliesForNextPhase();
        }
        
        SceneManager.LoadScene(4);
    }
}