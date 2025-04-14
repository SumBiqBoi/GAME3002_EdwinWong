using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Button startButton;

    public void StartGameButton()
    {
        SceneManager.LoadScene("game");
    }
}
