using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);
                // Здесь можно вызвать событие окончания таймера
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
