using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopState : AbstractGameState
{
    GameObject shopScreen;

    Button startDeliveryButton;

    public ShopState(GameObject shopScreen)
    {
        this.shopScreen = shopScreen;

        foreach (Transform child in shopScreen.transform)
        {
            if (child.name == "StartDeliveryButton")
            {
                startDeliveryButton = child.gameObject.GetComponent<Button>();
            }
        }

        startDeliveryButton.onClick.AddListener(StartDeliveryOnClick);
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

    public void StartDeliveryOnClick()
    {
        GameStateManager.PushGameStateOnStack(GameStateManager.gameState);
    }
}
