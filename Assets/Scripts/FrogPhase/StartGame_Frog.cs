using UnityEngine;

public class StartGame_Frog : MonoBehaviour

{
    public GameObject startMenuPanel;
    public CountdownTimer timerScript;
    public CountdownBar barScript;
    public GameObject backgroundPanel;

    void Start()
    {
        Time.timeScale = 0f; // заморозить игру
        startMenuPanel.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        startMenuPanel.SetActive(false);
        Time.timeScale = 1f; // разморозить игру
        timerScript.StartTimer();
        barScript.StartBar();
        backgroundPanel.SetActive(false);
    }
}

