using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameOver gameOverScript;

    [SerializeField] GameObject pinball;
    [SerializeField] GameObject startPosition;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text pinballAmountText;
    [SerializeField] GameObject gameOver;

    private int score = 0;
    private int pinballCount = 3;

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
                    gameOverScript.highScoreText.text = scoreText.text;
                }
                gameOverScript.finalScoreText.text = scoreText.text;
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
            pinball.transform.position = startPosition.transform.position;
            pinballCount--;
            pinballAmountText.text = "Pinballs Left: " + pinballCount;
        }
    }
}
