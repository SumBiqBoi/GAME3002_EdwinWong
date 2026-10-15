using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    bool isOnShopTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOnShopTrigger)
        {
            if (other.gameObject.tag == "Player")
            {
                GameStateManager.PushGameStateOnStack(GameStateManager.shopState);

                isOnShopTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOnShopTrigger = false;
    }
}
