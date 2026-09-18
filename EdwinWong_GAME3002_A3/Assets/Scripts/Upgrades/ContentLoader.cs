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
    public static UpgradeItemData LoadUpgradeItem(ItemType type, Upgrades upgrades)
    {
        UpgradeItemData upgradeItemData;

        string itemName = "";
        string itemDesc = "";
        string currentStat = "";
        string upgradedStat = "";

        float addedStat = 0;

        if (type == ItemType.CurrentEnergy)
        {
            addedStat = 20;

            itemName = "Current Energy";
            itemDesc = "Increases current energy by " + addedStat;
            currentStat = upgrades.GetCurrentEnergy().ToString();
            upgradedStat = (addedStat + upgrades.GetCurrentEnergy()).ToString();
        }
        else if (type == ItemType.MaxEnergy)
        {
            addedStat = 50;

            itemName = "Max Energy";
            itemDesc = "Increases maximum energy by " + addedStat;
            currentStat = upgrades.GetMaxEnergy().ToString();
            upgradedStat = (addedStat + upgrades.GetMaxEnergy()).ToString();
        }
        else if (type == ItemType.Income)
        {
            addedStat = 1;

            itemName = "Income";
            itemDesc = "Increases earnings from all sources by " + addedStat;
            currentStat = upgrades.GetCoinsHeld().ToString();
            upgradedStat = (addedStat + upgrades.GetCoinsHeld()).ToString();
        }
        else if (type == ItemType.MassIncrease)
        {
            addedStat = 1;

            itemName = "Mass Increase";
            itemDesc = "Increases the mass / weight of the cart by " + addedStat;
            currentStat = upgrades.GetMass().ToString();
            upgradedStat = (addedStat + upgrades.GetMass()).ToString();
        }
        else if (type == ItemType.Acceleration)
        {
            addedStat = 5;

            itemName = "Acceleration";
            itemDesc = "Increases acceleration of the cart by " + addedStat;
            currentStat = upgrades.GetAcceleration().ToString();
            upgradedStat = (addedStat + upgrades.GetAcceleration()).ToString();
        }
        else if (type == ItemType.MaxSpeed)
        {
            addedStat = 10;

            itemName = "Max Speed";
            itemDesc = "Increases the max speed of the cart by " + addedStat;
            currentStat = upgrades.GetMaxSpeed().ToString();
            upgradedStat = (addedStat + upgrades.GetMaxSpeed()).ToString();
        }
        else if (type == ItemType.RotateSpeed)
        {
            addedStat = 5;

            itemName = "Rotate Speed";
            itemDesc = "Increase the rotational speed of the cart by " + addedStat;
            currentStat = upgrades.GetRotateSpeed().ToString();
            upgradedStat = (addedStat + upgrades.GetRotateSpeed()).ToString();
        }
        else if (type == ItemType.ContainerStrength)
        {
            addedStat = 3;

            itemName = "ContainerStrength";
            itemDesc = "Increases the amount of hits the container by " + addedStat;
            currentStat = upgrades.GetContainerStrength().ToString();
            upgradedStat = (addedStat + upgrades.GetContainerStrength()).ToString();
        }

        upgradeItemData = new UpgradeItemData(itemName, itemDesc, currentStat, upgradedStat);
        return upgradeItemData;
    }
}
