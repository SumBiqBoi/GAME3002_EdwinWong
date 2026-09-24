using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour
{
    UpgradeShop upgradeShop;
    UpgradeItemData upgradeItemData;

    GameObject menuPopUp;

    TMP_Text itemName;
    TMP_Text itemDesc;

    TMP_Text currentStat;
    TMP_Text upgradedStat;

    Button backOutButton;
    public Button buyButton;
    public Button sellButton;

    public ItemType upgradeCounter;

    void Start()
    {
        upgradeShop = GetComponentInParent<UpgradeShop>();
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
            else if (child.name == "BuyButton")
            {
                buyButton = child.gameObject.GetComponent<Button>();
                buyButton.onClick.AddListener(BuyClick);
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
        upgradeItemData = ContentLoader.LoadUpgradeItem(itemType);

        itemName.text = upgradeItemData.itemName;
        itemDesc.text = upgradeItemData.itemDesc;
        currentStat.text = upgradeItemData.currentStat;
        upgradedStat.text = upgradeItemData.upgradedStat;

        upgradeCounter = itemType;

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

    public void BuyClick()
    {
        if (upgradeCounter == ItemType.CurrentEnergy)
        {
            ContentLoader.UpgradesStats().AddCurrentEnergy(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.MaxEnergy)
        {
            ContentLoader.UpgradesStats().AddMaxEnergy(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.Income)
        {
            ContentLoader.UpgradesStats().AddCoinsHeld(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.MassIncrease)
        {
            ContentLoader.UpgradesStats().AddMass(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.Acceleration)
        {
            ContentLoader.UpgradesStats().AddAcceleration(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.MaxSpeed)
        {
            ContentLoader.UpgradesStats().AddMaxSpeed(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.RotateSpeed)
        {
            ContentLoader.UpgradesStats().AddRotateSpeed(upgradeItemData.addedStat);
        }
        else if (upgradeCounter == ItemType.ContainerStrength)
        {
            ContentLoader.UpgradesStats().AddContainerStrength(upgradeItemData.addedStat);
        }

        InitializePopUp(upgradeCounter);
        upgradeShop.CoinsHeldTextUpdate();
    }
}
