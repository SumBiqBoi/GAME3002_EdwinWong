using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    [SerializeField] GameObject[] objectToLaunch;
    [SerializeField] Transform launchDirection;
    [SerializeField] float launchSpeed = 2;
    [SerializeField] float delay = 0;

    bool isActivated = false;

    private void Update()
    {
        if (isActivated)
        {
            if (delay <=  0)
            {
                Launch();

                isActivated = false;
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }
    }

    public void ActivateLaunch()
    {
        isActivated = true;
    }

    void Launch()
    {
        foreach (GameObject obj in objectToLaunch)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().AddForce(launchDirection.forward * launchSpeed, ForceMode.Impulse);
        }
    }
}
