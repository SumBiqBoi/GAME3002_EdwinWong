using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    [SerializeField] GameObject[] objectToLaunch;
    [SerializeField] Transform launchDirection;
    [SerializeField] float launchSpeed = 2;
    public void ActivateLaunch()
    {
        foreach (GameObject obj in objectToLaunch)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().AddForce(launchDirection.forward * launchSpeed, ForceMode.Impulse);
        }
    }
}
