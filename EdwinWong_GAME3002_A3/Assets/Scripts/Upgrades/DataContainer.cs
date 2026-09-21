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

public class Upgrades
{
    public float currentEnergy { get; private set; }
    public float maxEnergy { get; private set; }

    public int coinsHeld { get; private set; }

    public float mass { get; private set; }
    public float acceleration { get; private set; }
    public float maxSpeed { get; private set; }
    public float rotateSpeed { get; private set; }

    public int containerStrength;

    public Upgrades(float currentEnergy, float maxEnergy, int coinsHeld, float mass, float acceleration, float maxSpeed, float rotateSpeed, int containerStrength)
    {
        this.currentEnergy = currentEnergy;
        this.maxEnergy = maxEnergy;
        this.coinsHeld = coinsHeld;
        this.mass = mass;
        this.acceleration = acceleration;
        this.maxSpeed = maxSpeed;
        this.rotateSpeed = rotateSpeed;
        this.containerStrength = containerStrength;
    }

    public void AddCurrentEnergy(float value)
    {
        currentEnergy += value;
    }

    public void AddMaxEnergy(float value)
    {
        maxEnergy += value;
    }

    public void AddCoinsHeld(int value)
    {
        coinsHeld += value;
    }

    public void AddMass(float value)
    {
        mass += value;
    }

    public void AddAcceleration(float value)
    {
        acceleration += value;
    }

    public void SubtractAcceleration(float value)
    {
        acceleration -= value;
    }

    public void AddMaxSpeed(float value)
    {
        maxSpeed += value;
    }

    public void AddRotateSpeed(float value)
    {
        rotateSpeed += value;
    }

    public void AddContainerStrength(int value)
    {
        containerStrength += value;
    }
}

