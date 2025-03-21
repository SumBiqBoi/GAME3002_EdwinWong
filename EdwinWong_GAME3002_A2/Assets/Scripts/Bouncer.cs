using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    float bounceForce = 2;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // Normal calculation
        Vector3 surfaceNormal = collision.contacts[0].normal;

        // Direction calculation
        // direction = destination - source

        //Vector3 direction = transform.position - collision.gameObject.transform.forward;

        Vector3 velocity = rb.velocity;

        float beforeSpeed = velocity.magnitude;

        Vector3 collisionDirection = Vector3.Reflect(velocity, surfaceNormal);
        
        rb.velocity = collisionDirection.normalized * beforeSpeed * bounceForce;

        if (surfaceNormal.y > 0.5f)
        {
            rb.AddForce(Vector3.up * Mathf.Abs(beforeSpeed) * bounceForce, ForceMode.Impulse);
        }
    }
}
