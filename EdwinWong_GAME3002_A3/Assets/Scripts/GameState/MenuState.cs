using UnityEngine;
using UnityEngine.UI;

public class MenuState : AbstractGameState
{
    GameObject menuScreen;

    Button newGameButton;
    Button continueButton;
    Button optionsButton;
    Button quitButton;

    public MenuState(GameObject menuScreen)
    {
        this.menuScreen = menuScreen;

        foreach (Transform child in menuScreen.transform)
        {
            if (child.name == "NewGameButton")
            {
                newGameButton = child.gameObject.GetComponent<Button>();
            }
            else if (child.name == "ContinueButton")
            {
                continueButton = child.gameObject.GetComponent<Button>();
            }
            else if (child.name == "OptionsButton")
            {
                optionsButton = child.gameObject.GetComponent<Button>();
            }
            else if (child.name == "QuitButton")
            {
                quitButton = child.gameObject.GetComponent<Button>();
            }
        }

        newGameButton.onClick.AddListener(NewGameClick);
        continueButton.onClick.AddListener(ContinueClick);
        optionsButton.onClick.AddListener(OptionsClick);
        quitButton.onClick.AddListener(QuitClick);
    }

    public override void LoadGameState()
    {
        menuScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        menuScreen.SetActive(false);
    }

    public override void Pause()
    {
        menuScreen.SetActive(false);
    }

    public override void Resume()
    {
        menuScreen.SetActive(true);
    }

    public override void Update()
    {
        
    }

    public void NewGameClick()
    {
        GameStateManager.PushGameStateOnStack(GameStateManager.shopState);
    }

    public void ContinueClick()
    {
        GameStateManager.PushGameStateOnStack(GameStateManager.shopState);
    }

    public void OptionsClick()
    {

    }

    public void QuitClick()
    {
        Application.Quit();
    }
}
