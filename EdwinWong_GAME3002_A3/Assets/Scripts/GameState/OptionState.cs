using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionState : AbstractGameState
{
    GameObject optionScreen;

    public OptionState(GameObject gameScreen)
    {
        this.optionScreen = gameScreen;
    }

    public override void LoadGameState()
    {
        optionScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        optionScreen.SetActive(false);
    }

    public override void Pause()
    {
        optionScreen.SetActive(false);
    }

    public override void Resume()
    {
        optionScreen.SetActive(true);
    }

    public override void Update()
    {

    }
}
