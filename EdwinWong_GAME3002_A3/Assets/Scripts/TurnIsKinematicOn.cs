using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIsKinematicOn : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StopObject")
        {
            rb.isKinematic = true;
        }
    }
}
