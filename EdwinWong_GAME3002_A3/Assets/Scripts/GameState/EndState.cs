using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndState : AbstractGameState
{
    GameObject endScreen;

    TMP_Text timeInLevelText;

    Button mainMenuButton;
    Button restartButton;

    public EndState(GameObject endScreen)
    {
        this.endScreen = endScreen;

        foreach (Transform child in endScreen.transform)
        {
            if (child.name == "TimeInLevelText")
            {
                timeInLevelText = child.gameObject.GetComponent<TMP_Text>();
            }
            else if (child.name == "MainMenuButton")
            {
                mainMenuButton = child.gameObject.GetComponent<Button>();
                mainMenuButton.onClick.AddListener(MainMenuClick);
            }
            else if (child.name == "RestartButton")
            {
                restartButton = child.gameObject.GetComponent<Button>();
                restartButton.onClick.AddListener(RestartClick);
            }
        }
    }

    public override void LoadGameState()
    {
        endScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        endScreen.SetActive(false);

        Timer.ResetTimer();
    }

    public override void Pause()
    {
        endScreen.SetActive(false);
    }

    public override void Resume()
    {
        endScreen.SetActive(true);
    }

    public override void Update()
    {

    }

    void MainMenuClick()
    {
        GameStateManager.PopGameUntilStateIs(GameStateManager.menuState);
    }

    void RestartClick()
    {
        GameStateManager.PopGameUntilStateIs(GameStateManager.shopState);
    }
}
