using UnityEngine;
using UnityEngine.UI;

public class CountdownBar : MonoBehaviour
{
    public float totalTime = 30f;
    private float timeRemaining;
    public Image progressBar;
    public bool barIsRunning = false;

    void Start()
    {
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (barIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float progress = timeRemaining / totalTime;
                progressBar.fillAmount = progress;
            }
        }
    }

    public void StartBar()
    {
        barIsRunning = true;
    }
}
