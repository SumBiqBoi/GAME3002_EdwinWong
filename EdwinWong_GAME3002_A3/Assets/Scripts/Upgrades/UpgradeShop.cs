using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    MenuPopUp menuPopUp;

    Button currentEnergyButton;
    Button maxEnergyButton;
    Button incomeButton;
    Button massButton;
    Button accelerationButton;
    Button maxSpeedButton;
    Button rotateSpeedButton;
    Button containerStrengthButton;

    void Start()
    {
        InitializeUpgradeShop();

        ContentLoader.UpgradesStats();
    }

    void InitializeUpgradeShop()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "MenuPopUp")
            {
                menuPopUp = child.gameObject.GetComponent<MenuPopUp>();
            }
            else if (child.name == "CurrentEnergyButton")
            {
                currentEnergyButton = child.gameObject.GetComponent<Button>();
                currentEnergyButton.onClick.AddListener(EnergyUpgradeClick);
            }
            else if (child.name == "MaxEnergyButton")
            {
                maxEnergyButton = child.gameObject.GetComponent<Button>();
                maxEnergyButton.onClick.AddListener(MaxEnergyUpgradeClick);
            }
            else if (child.name == "IncomeButton")
            {
                incomeButton = child.gameObject.GetComponent<Button>();
                incomeButton.onClick.AddListener(IncomeUpgradeClick);
            }
            else if (child.name == "MassButton")
            {
                massButton = child.gameObject.GetComponent<Button>();
                massButton.onClick.AddListener(MassUpgradeClick);
            }
            else if (child.name == "AccelerationButton")
            {
                accelerationButton = child.gameObject.GetComponent<Button>();
                accelerationButton.onClick.AddListener(AccelerationUpgradeClick);
            }
            else if (child.name == "MaxSpeedButton")
            {
                maxEnergyButton = child.gameObject.GetComponent<Button>();
                maxEnergyButton.onClick.AddListener(MaxEnergyUpgradeClick);
            }
            else if (child.name == "RotateSpeedButton")
            {
                rotateSpeedButton = child.gameObject.GetComponent<Button>();
                rotateSpeedButton.onClick.AddListener(RotateSpeedUpgradeClick);
            }
            else if (child.name == "ContainerStrengthButton")
            {
                containerStrengthButton = child.gameObject.GetComponent<Button>();
                containerStrengthButton.onClick.AddListener(ContainerStrengthUpgradeClick);
            }
        }
    }

    public void EnergyUpgradeClick()
    {
        menuPopUp.MovePopUp(currentEnergyButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.CurrentEnergy);
    }

    public void MaxEnergyUpgradeClick()
    {
        menuPopUp.MovePopUp(maxEnergyButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.MaxEnergy);
    }

    public void IncomeUpgradeClick()
    {
        menuPopUp.MovePopUp(incomeButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.Income);
    }

    public void MassUpgradeClick()
    {
        menuPopUp.MovePopUp(massButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.MassIncrease);
    }

    public void AccelerationUpgradeClick()
    {
        menuPopUp.MovePopUp(accelerationButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.Acceleration);
    }

    public void MaxSpeedUpgradeClick()
    {
        menuPopUp.MovePopUp(maxSpeedButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.MaxSpeed);
    }

    public void RotateSpeedUpgradeClick()
    {
        menuPopUp.MovePopUp(rotateSpeedButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.RotateSpeed);
    }

    public void ContainerStrengthUpgradeClick()
    {
        menuPopUp.MovePopUp(containerStrengthButton.gameObject);
        menuPopUp.InitializePopUp(ItemType.ContainerStrength);
    }
}
