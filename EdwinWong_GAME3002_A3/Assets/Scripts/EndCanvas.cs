using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public static EndCanvas instance;

    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] public GameObject endCanvas;

    float score;
    float highScore;

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

    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
        endCanvas.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
        endCanvas.SetActive(false);
    }
}
