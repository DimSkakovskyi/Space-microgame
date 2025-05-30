using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimeCounter : MonoBehaviour
{
    Text timeUI;

    float startTime; // Time when the game starts
    float ellapsedTime; // Time elapsed since the game started
    bool startCounter; // Flag to check if the game is running

    int minutes; // Minutes elapsed
    int seconds; // Seconds elapsed

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false; // Start the counter

        timeUI = GetComponent<Text>(); // Get the Text component for displaying time
    }

    public void StartTimeCounter()
    {
        startTime = Time.time; // Record the start time
        startCounter = true; // Set the flag to true to start counting
    }

    public void StopTimeCounter()
    {
        startCounter = false; // Set the flag to false to stop counting
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            ellapsedTime = Time.time - startTime; // Calculate elapsed time
            minutes = (int)ellapsedTime / 60; // Calculate minutes
            seconds = (int)ellapsedTime % 60; // Calculate seconds

            // Format the time as MM:SS and update the UI
            timeUI.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        }    
        
    }
}
