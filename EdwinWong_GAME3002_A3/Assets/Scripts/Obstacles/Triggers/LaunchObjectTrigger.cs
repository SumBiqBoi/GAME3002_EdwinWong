using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObjectTrigger : MonoBehaviour
{
    LaunchObject launchObject;

    private void Start()
    {
        launchObject = GetComponentInParent<LaunchObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player")
            {
                launchObject.ActivateLaunch();
            }
    }
}
