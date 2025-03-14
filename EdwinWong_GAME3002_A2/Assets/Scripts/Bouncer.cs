using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    [SerializeField] float bounceForce = 20;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        Vector3 displacement = collision.gameObject.transform.position - transform.position;

        float distance = displacement.magnitude;

        //Get Velocity and Normalize it from the collisions.contact[0]

        Vector3 velocity = rb.velocity;

        float beforeSpeed = velocity.magnitude;
        Vector3 collisionDirection = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

        rb.velocity = new Vector3(collisionDirection.x, 0.0f, collisionDirection.z) * bounceForce;
    }
}
