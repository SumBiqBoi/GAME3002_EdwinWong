using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] Button restartButton;
    [SerializeField] public TMP_Text finalScoreText;
    [SerializeField] public TMP_Text highScoreText;

    public float highScore;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        finalScoreText.text = "0";
    }
}
