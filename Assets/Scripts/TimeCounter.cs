using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use this for TextMeshPro

public class TimeCounter : MonoBehaviour
{
    TextMeshProUGUI timeUI;

    float startTime;
    float ellapsedTime;
    bool startCounter;

    int minutes;
    int seconds;

    void Start()
    {
        StartTimeCounter();

        timeUI = GetComponent<TextMeshProUGUI>();
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void ResumeTimeCounter()
    {
        startCounter = true;
    }

    public void StopTimeCounter()
    {
        startCounter = false;
    }

    void Update()
    {
        if (startCounter)
        {
            ellapsedTime = Time.time - startTime;
            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
