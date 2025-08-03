using UnityEngine;

public class StartGame_Frog : MonoBehaviour

{
    public GameObject startMenuPanel;
    public CountdownTimer timerScript;
    public CountdownBar barScript;
    public GameObject backgroundPanel;

    void Start()
    {
        Time.timeScale = 0f; // ���������� ����
        startMenuPanel.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        startMenuPanel.SetActive(false);
        Time.timeScale = 1f; // ����������� ����
        timerScript.StartTimer();
        barScript.StartBar();
        backgroundPanel.SetActive(false);
    }
}

