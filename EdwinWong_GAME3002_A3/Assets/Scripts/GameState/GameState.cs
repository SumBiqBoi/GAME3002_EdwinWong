using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : AbstractGameState
{
    GameObject gameScreen;
    
    public GameState(GameObject gameScreen)
    {
        this.gameScreen = gameScreen;
    }

    public override void LoadGameState()
    {
        gameScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        gameScreen.SetActive(false);
    }

    public override void Pause()
    {
        gameScreen.SetActive(false);
    }

    public override void Resume()
    {
        gameScreen.SetActive(true);
    }

    public override void Update()
    {
        
    }
}
