using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsIce : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wheels")
        {
            PhysicMaterial physicMaterial = other.gameObject.GetComponent<PhysicMaterial>();

            if (physicMaterial != null )
            {
                physicMaterial.staticFriction = 0.1f;
                physicMaterial.dynamicFriction = 0.1f;
            }
        }
    }
}
