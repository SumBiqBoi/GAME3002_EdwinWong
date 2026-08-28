using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshCollider>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloorBreaker")
        {
            BreakFloor();
        }
    }

    void BreakFloor()
    {
        //gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshCollider>().enabled = true;
            child.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
