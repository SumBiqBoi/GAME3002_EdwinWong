using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameOver gameOverScript;

    [SerializeField] public GameObject pinball;
    [SerializeField] public GameObject startPosition;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text pinballAmountText;
    [SerializeField] GameObject gameOver;

    public int score = 0;
    public int pinballCount = 1;

    void Start()
    {
        gameOverScript = FindObjectOfType<GameOver>();
        scoreText.text = "Score: " + score;
        pinballAmountText.text = "Pinballs Left: " + pinballCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bouncer")
        {
            score += 100;
            scoreText.text = "Score: " + score;
        }
        if (collision.gameObject.tag == "EndZone")
        {
            if (pinballCount == 0)
            {
                if (score >= gameOverScript.highScore)
                {
                    gameOverScript.highScore = score;
                    gameOverScript.highScoreText.text = "" + gameOverScript.highScore;
                }
                gameOverScript.finalScoreText.text = "" + score;
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pinball.transform.position = startPosition.transform.position;
                pinballCount--;
            }
            pinballAmountText.text = "Pinballs Left: " + pinballCount;
        }
    }
}
