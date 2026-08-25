using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LaunchObjectTrigger : MonoBehaviour
{
    [SerializeField] GameObject objectToLaunch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToLaunch.GetComponent<Rigidbody>().isKinematic = false;
            objectToLaunch.GetComponent<Rigidbody>().AddForce(Vector3.forward * -2, ForceMode.Impulse);
        }
    }
}
