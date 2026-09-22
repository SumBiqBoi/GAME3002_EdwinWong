using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour
{
    GameObject menuPopUp;

    TMP_Text itemName;
    TMP_Text itemDesc;

    TMP_Text currentStat;
    TMP_Text upgradedStat;

    Button backOutButton;
    public Button buyButton;
    public Button sellButton;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Menu")
            {
                menuPopUp = child.gameObject;
            }
        }

        foreach (Transform child in menuPopUp.transform)
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
            else if (child.name == "BackOutButton")
            {
                backOutButton = child.gameObject.GetComponent<Button>();
                backOutButton.onClick.AddListener(BackOutClick);
            }
        }

        DisablePopUp();
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

    public void BackOutClick()
    {
        DisablePopUp();
    }

    public void EnablePopUp()
    {
        menuPopUp.SetActive(true);
    }

    public void DisablePopUp()
    {
        menuPopUp.SetActive(false);
    }

    public void Buy()
    {

    }
}
