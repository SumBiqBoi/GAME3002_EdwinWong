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

    void Start()
    {
        ballLaunchScript = FindObjectOfType<BallLaunch>();
        timerScript = GetComponentInChildren<Timer>();
    }

    void Update()
    {
        SliderBar(ballLaunchScript.launchSpeed, ballLaunchScript.launchSpeedMax);

        if (ballLaunchScript.isAtStart == false)
        {
            textLaunchSpeed.text = "Launch Speed: " + ballLaunchScript.launchSpeed;
            textMaxHeight.text = "Max Height: " + ballLaunchScript.maxHeight;
            textMaxRange.text = "Max Range: " + ballLaunchScript.maxRange;
            textXAxisAngle.text = "X Axis Angle: " + ballLaunchScript.launchAngleX;
            textYAxisAngle.text = "Y Axis Angle: " + ballLaunchScript.launchAngleY;
            textAirTime.text = "Air Time: " + ballLaunchScript.airTime;
        }
        textTimeLeft.text = "Time Left: " + timerScript.remainingTime.ToString("F0");
        textScoreCounter.text = "Score: " + ballLaunchScript.score;
    }

    void SliderBar(float min, float max)
    {
        sliderLaunchSpeed.value = min / max;
    }
}
