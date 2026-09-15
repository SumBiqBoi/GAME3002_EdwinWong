using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Button startButton;

    [SerializeField] GameObject titleState;
    [SerializeField] GameObject menuState;
    [SerializeField] GameObject gameState;


    public void StartGameButton()
    {
        SceneManager.LoadScene("game");
    }

    public void RunState(GameObject state)
    {
        state.SetActive(true);
    }
}
