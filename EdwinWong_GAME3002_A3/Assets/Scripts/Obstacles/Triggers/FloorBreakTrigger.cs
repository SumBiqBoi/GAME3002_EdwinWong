using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreakTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject go in gameObjects)
            {
                go.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
