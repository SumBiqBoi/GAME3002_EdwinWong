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
        isEnergyDepleting = false;

        currentEnergy = maxEnergy;
    }

    void Update()
    {
        if (isEnergyDepleting)
        {
            currentEnergy -= Time.deltaTime;

            if (currentEnergy <= 0)
            {
                // End game;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Energy")
        {
            isEnergyDepleting = !isEnergyDepleting;
        }
    }
}
