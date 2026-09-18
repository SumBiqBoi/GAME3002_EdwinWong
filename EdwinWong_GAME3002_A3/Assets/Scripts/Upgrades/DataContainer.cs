using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemData
{
    public string itemName;
    public string itemDesc;
    public string currentStat;
    public string upgradedStat;

    public UpgradeItemData(string itemName, string itemDesc, string currentStat, string upgradedStat)
    {
        this.itemName = itemName;
        this.itemDesc = itemDesc;
        this.currentStat = currentStat;
        this.upgradedStat = upgradedStat;
    }
}
