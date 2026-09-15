using UnityEngine;
using UnityEngine.UI;

public class TitleState : AbstractGameState
{
    GameObject titleScreen;

    Button startButton;

    public TitleState(GameObject titleScreen)
    {
        this.titleScreen = titleScreen;

        foreach (Transform child in titleScreen.transform)
        {
            if (child.name == "StartButton")
            {
                startButton = child.gameObject.GetComponent<Button>();
            }
        }

        startButton.onClick.AddListener(TitleScreenStartClick);
    }

    public override void LoadGameState()
    {
        titleScreen.SetActive(true);

        Debug.Log("Title Loaded");
    }

    public override void UnloadGameState()
    {
        titleScreen.SetActive(false);
    }

    public override void Pause()
    {
        titleScreen.SetActive(false);
    }

    public override void Resume()
    {
        titleScreen.SetActive(true);
    }

    public override void Update()
    {
        
    }

    public void TitleScreenStartClick()
    {
        GameStateManager.PushGameStateOnStack(GameStateManager.menuState);
    }
}
