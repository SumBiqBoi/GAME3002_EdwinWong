using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherTriggers : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
        }
    }
}
