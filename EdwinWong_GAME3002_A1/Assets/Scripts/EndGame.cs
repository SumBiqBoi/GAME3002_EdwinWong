using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] BallLaunch ballLaunchScript;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] Button restart;
    [SerializeField] Button quit;

    [SerializeField] Canvas endCanvas;
    [SerializeField] Canvas hudCanvas;

    float currentScore;
    float highScore;

    void Start()
    {
        ballLaunchScript = FindObjectOfType<BallLaunch>();
        endCanvas.enabled = false;
    }

    private void Update()
    {
        // Updates current score
        currentScore = ballLaunchScript.score;

        currentScoreText.text = "Current Score: " + currentScore.ToString();

        // If current score higher than high score, update high score
        if (currentScore >= highScore)
        {
            highScore = currentScore;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void RestartGame()
    {
        hudCanvas.enabled = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
