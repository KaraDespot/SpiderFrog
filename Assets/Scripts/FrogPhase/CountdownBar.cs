using UnityEngine;
using UnityEngine.UI;

public class CountdownBar : MonoBehaviour
{
    public float totalTime = 30f;
    private float timeRemaining;
    public Slider progressBar;
    public bool barIsRunning = false;

    void Start()
    {
        timeRemaining = totalTime;

        // Убедимся, что значение слайдера от 0 до 1
        if (progressBar != null)
        {
            progressBar.minValue = 0f;
            progressBar.maxValue = 1f;
            progressBar.value = 1f;
        }
    }

    void Update()
    {
        if (barIsRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float progress = timeRemaining / totalTime;

            if (progressBar != null)
            {
                progressBar.value = progress;
            }
        }
    }

    public void StartBar()
    {
        barIsRunning = true;
    }
}
