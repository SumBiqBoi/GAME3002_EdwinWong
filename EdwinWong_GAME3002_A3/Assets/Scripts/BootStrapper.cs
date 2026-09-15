using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject menuScreen;
    public GameObject shopScreen;
    public GameObject gameScreen;
    public GameObject endScreen;

    void Start()
    {
        titleScreen.SetActive(false);
        menuScreen.SetActive(false);
        shopScreen.SetActive(false);
        gameScreen.SetActive(false);
        endScreen.SetActive(false);

        GameStateManager.Initialize(this);
    }

    void Update()
    {
        GameStateManager.Update();
    }
}
