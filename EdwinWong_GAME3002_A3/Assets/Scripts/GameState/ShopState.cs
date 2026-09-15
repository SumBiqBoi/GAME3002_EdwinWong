using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopState : AbstractGameState
{
    GameObject shopScreen;

    Button PlayGameButton;

    public ShopState(GameObject shopScreen)
    {
        this.shopScreen = shopScreen;
    }

    public override void LoadGameState()
    {
        shopScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        shopScreen.SetActive(false);
    }

    public override void Pause()
    {
        shopScreen.SetActive(false);
    }

    public override void Resume()
    {
        shopScreen.SetActive(true);
    }

    public override void Update()
    {
        
    }
}
