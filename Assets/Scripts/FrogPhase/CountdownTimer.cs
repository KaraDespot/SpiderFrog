using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    public bool timerIsRunning = false; // теперь по умолчанию false

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

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
