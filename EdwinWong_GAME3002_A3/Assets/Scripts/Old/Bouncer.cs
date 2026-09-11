using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] float bounceForce;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody collisionRB = collision.gameObject.GetComponent<Rigidbody>();
        if (collisionRB != null)
        {
            Vector3 hitForce = collisionRB.transform.forward * -bounceForce;
            collisionRB.AddForce(hitForce, ForceMode.Impulse);
        }
    }
}
