using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public static EndCanvas instance;

    [SerializeField] Timer timerScript;
    [SerializeField] public GameObject endCanvas;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    float score;
    float highScore;
    public float multiplierValue = 1;

    public bool hasSphere = true;
    public bool hasCapsule = true;
    public bool hasCube = true;

    public bool isCanvasTrue;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        timerScript = FindFirstObjectByType<Timer>();
        endCanvas.SetActive(false);
        isCanvasTrue = false;
    }

    private void Update()
    {
        score = (multiplierValue / timerScript.elapsedTime) * 100000;

        scoreText.text = score.ToString("F0");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
        endCanvas.SetActive(false);
        isCanvasTrue = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
        endCanvas.SetActive(false);
        isCanvasTrue = false;
        Time.timeScale = 1f;
    }
}
