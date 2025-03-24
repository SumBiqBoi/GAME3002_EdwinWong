using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] GameObject gameOver;
    [SerializeField] Button restartButton;
    [SerializeField] public TMP_Text finalScoreText;
    [SerializeField] public TMP_Text highScoreText;

    private void Start()
    {
        uiHandler = FindObjectOfType<UIHandler>();
        gameOver.SetActive(false);
    }

    public void RestartGame()
    {
        uiHandler.pinball.transform.position = uiHandler.startPosition.transform.position;
        uiHandler.score = 0;
        uiHandler.scoreText.text = "Score: " + uiHandler.score;
        uiHandler.pinballCount = 1;
        uiHandler.pinballAmountText.text = "Pinballs Left: " + uiHandler.pinballCount;
        gameOver.SetActive(false);
        Time.timeScale = 1;
        
    }
}
