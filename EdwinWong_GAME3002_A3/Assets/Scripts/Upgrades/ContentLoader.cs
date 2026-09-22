using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    CurrentEnergy,
    MaxEnergy,
    Income,
    MassIncrease,
    Acceleration,
    MaxSpeed,
    RotateSpeed,
    ContainerStrength
}

public static class ContentLoader
{
    private static Upgrades upgrades = new Upgrades(
        10,     // Current energy
        100,    // Max energy
        25,     // Coins held
        1,      // Mass
        20,     // Acceleration
        4,      // Max speed
        150,    // Rotate speed
        0       // Container strength
        );

    public static Upgrades UpgradesStats()
    {
        return upgrades;
    }

    public static UpgradeItemData LoadUpgradeItem(ItemType type)
    {
        UpgradeItemData upgradeItemData;

        string itemName = "";
        string itemDesc = "";
        string currentStat = "";
        string upgradedStat = "";

        int addedStat = 0;

        if (type == ItemType.CurrentEnergy)
        {
            addedStat = 20;

            itemName = "Current Energy";
            itemDesc = "Increases current energy by " + addedStat;
            currentStat = upgrades.currentEnergy.ToString();
            upgradedStat = (addedStat + upgrades.currentEnergy).ToString();
        }
        else if (type == ItemType.MaxEnergy)
        {
            addedStat = 50;

            itemName = "Max Energy";
            itemDesc = "Increases maximum energy by " + addedStat;
            currentStat = upgrades.maxEnergy.ToString();
            upgradedStat = (addedStat + upgrades.maxEnergy).ToString();
        }
        else if (type == ItemType.Income)
        {
            addedStat = 1;

            itemName = "Income";
            itemDesc = "Increases earnings from all sources by " + addedStat;
            currentStat = upgrades.coinsHeld.ToString();
            upgradedStat = (addedStat + upgrades.coinsHeld).ToString();
        }
        else if (type == ItemType.MassIncrease)
        {
            addedStat = 1;

            itemName = "Mass Increase";
            itemDesc = "Increases the mass / weight of the cart by " + addedStat;
            currentStat = upgrades.mass.ToString();
            upgradedStat = (addedStat + upgrades.mass).ToString();
        }
        else if (type == ItemType.Acceleration)
        {
            addedStat = 5;

            itemName = "Acceleration";
            itemDesc = "Increases acceleration of the cart by " + addedStat;
            currentStat = upgrades.acceleration.ToString();
            upgradedStat = (addedStat + upgrades.acceleration).ToString();
        }
        else if (type == ItemType.MaxSpeed)
        {
            addedStat = 10;

            itemName = "Max Speed";
            itemDesc = "Increases the max speed of the cart by " + addedStat;
            currentStat = upgrades.maxSpeed.ToString();
            upgradedStat = (addedStat + upgrades.maxSpeed).ToString();
        }
        else if (type == ItemType.RotateSpeed)
        {
            addedStat = 5;

            itemName = "Rotate Speed";
            itemDesc = "Increase the rotational speed of the cart by " + addedStat;
            currentStat = upgrades.rotateSpeed.ToString();
            upgradedStat = (addedStat + upgrades.rotateSpeed).ToString();
        }
        else if (type == ItemType.ContainerStrength)
        {
            addedStat = 3;

            itemName = "ContainerStrength";
            itemDesc = "Increases the amount of hits the container by " + addedStat;
            currentStat = upgrades.containerStrength.ToString();
            upgradedStat = (addedStat + upgrades.containerStrength).ToString();
        }

        upgradeItemData = new UpgradeItemData(itemName, itemDesc, currentStat, upgradedStat, addedStat);
        return upgradeItemData;
    }
}
