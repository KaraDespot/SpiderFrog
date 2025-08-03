using UnityEngine;
using UnityEngine.UI;

public class CountdownBar : MonoBehaviour
{
    public float totalTime = 30f;
    private float timeRemaining;
    public Slider progressBar;

    void Start()
    {
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float progress = timeRemaining / totalTime;
            progressBar.value = progress; // если Slider
        }
    }
}
