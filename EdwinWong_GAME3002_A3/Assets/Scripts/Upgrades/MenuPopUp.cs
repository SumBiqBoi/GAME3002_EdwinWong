using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour
{
    TMP_Text itemName;
    TMP_Text itemDesc;

    TMP_Text currentStat;
    TMP_Text upgradedStat;

    public Button buyButton;
    public Button sellButton;

    void Start()
    {

        foreach (Transform child in transform)
        {
            if (child.name == "ItemName")
            {
                itemName = child.gameObject.GetComponent<TMP_Text>();
            }
            else if (child.name == "ItemDesc")
            {
                itemDesc = child.gameObject.GetComponent<TMP_Text>();
            }
            else if (child.name == "CurrentStat")
            {
                currentStat = child.gameObject.GetComponent<TMP_Text>();
            }
            else if (child.name == "UpgradedStat")
            {
                upgradedStat = child.gameObject.GetComponent<TMP_Text>();
            }
        }
    }

    public void InitializePopUp(ItemType itemType)
    {
        UpgradeItemData upgradeItemData = ContentLoader.LoadUpgradeItem(itemType);

        itemName.text = upgradeItemData.itemName;
        itemDesc.text = upgradeItemData.itemDesc;
        currentStat.text = upgradeItemData.currentStat;
        upgradedStat.text = upgradeItemData.upgradedStat;

        EnablePopUp();
    }

    public void MovePopUp(GameObject moveToGameObject)
    {
        DisablePopUp();

        gameObject.transform.position = moveToGameObject.transform.position;
    }

    public void EnablePopUp()
    {
        gameObject.SetActive(true);
    }

    public void DisablePopUp()
    {
        gameObject.SetActive(false);
    }

    public void Buy()
    {

    }
}
