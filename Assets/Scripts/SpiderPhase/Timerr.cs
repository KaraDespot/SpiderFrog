using UnityEngine;
using TMPro;

public class Timerr : MonoBehaviour
{
    public GameObject timeOverPanel;

    private float currentTime;
    public float startTime = 180f;

    void Start()
    {
        currentTime = startTime;
        timeOverPanel.SetActive(false);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0f;
            timeOverPanel.SetActive(true);
        }

    }
}

    