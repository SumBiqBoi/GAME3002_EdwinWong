using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Timer
{
    static TMP_Text timeText;

    public static bool isTimerRunning = false;

    public static float elapsedTime = 0;

    private static int minutes;
    private static int seconds;

    public static void InitTimer()
    {
        GameObject timeObject = GameObject.Find("Timer");

        if (timeObject != null)
        {
            timeText = timeObject.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.Log("Null");
        }
    }

    public static void UpdateTimer()
    {
        elapsedTime += 0.02f;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static void ResetTimer()
    {
        elapsedTime = 0;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
