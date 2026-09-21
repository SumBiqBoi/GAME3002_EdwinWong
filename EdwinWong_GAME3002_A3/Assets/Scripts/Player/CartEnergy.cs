using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartEnergy : MonoBehaviour
{
    public float currentEnergy;
    public float maxEnergy;

    bool isEnergyDepleting;

    void Start()
    {
        currentEnergy = ContentLoader.UpgradesStats().currentEnergy;
        maxEnergy = ContentLoader.UpgradesStats().maxEnergy;

        isEnergyDepleting = false;
    }

    void Update()
    {
        if (isEnergyDepleting)
        {
            currentEnergy -= Time.deltaTime;

            if (currentEnergy <= 0)
            {
                // End game;
                Debug.LogWarning("Game Ended");

                isEnergyDepleting = false;
            }

            Debug.Log("Energy: " +  currentEnergy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Energy")
        {
            isEnergyDepleting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Energy")
        {
            isEnergyDepleting = true;
        }
    }
}
