using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{

    [SerializeField] TMP_Text textLaunchSpeed;
    [SerializeField] TMP_Text textMaxHeight;
    [SerializeField] TMP_Text textMaxRange;
    [SerializeField] TMP_Text textXAxisAngle;
    [SerializeField] TMP_Text textYAxisAngle;
    [SerializeField] TMP_Text textAirTime;
    [SerializeField] TMP_Text textTimeLeft;
    [SerializeField] TMP_Text textScoreCounter;
    [SerializeField] Slider sliderLaunchSpeed;

    [SerializeField] BallLaunch ballLaunchScript;
    [SerializeField] Timer timerScript;

    [SerializeField] Canvas endCanvas;

    void Start()
    {
        ballLaunchScript = FindObjectOfType<BallLaunch>();
        timerScript = GetComponentInChildren<Timer>();
        gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void Update()
    {
        SliderBar(ballLaunchScript.launchSpeed, ballLaunchScript.launchSpeedMax);

        // Updating HUD text fields
        if (ballLaunchScript.isAtStart == false)
        {
            textLaunchSpeed.text = "Launch Speed: " + ballLaunchScript.launchSpeed;
            textMaxHeight.text = "Max Height: " + ballLaunchScript.maxHeight.ToString("F1");
            textMaxRange.text = "Max Range: " + ballLaunchScript.maxRange.ToString("F1");
            textAirTime.text = "Air Time: " + ballLaunchScript.airTime.ToString("F1");
        }
        textXAxisAngle.text = "X Axis Angle: " + ballLaunchScript.launchAngleX;
        textYAxisAngle.text = "Y Axis Angle: " + Mathf.Abs(ballLaunchScript.launchAngleY);
        textTimeLeft.text = "Time Left: " + timerScript.remainingTime.ToString("F0") + " sec";
        textScoreCounter.text = "Score: " + ballLaunchScript.score;

        // End the game
        if (timerScript.remainingTime <= 0)
        {
            Time.timeScale = 0;
            endCanvas.enabled = true;
        }
    }

    // Power slider input
    void SliderBar(float min, float max)
    {
        sliderLaunchSpeed.value = min / max;
    }
}
