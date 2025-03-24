using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] bool isSlowBumper = false;

    [SerializeField] float bounceForce;
    float minBounceSpeed = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (isSlowBumper)
        {
            bounceForce = 0.5f;
        }
        else
        {
            bounceForce = 3f;
        }
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // Original speed
        float beforeSpeed = rb.velocity.magnitude;
        if (beforeSpeed < 1)
        {
            beforeSpeed = 1;
        }

        Vector3 inDirection = rb.velocity.normalized;
        Vector3 inNormal = collision.contacts[0].normal;

        Vector3 collisionDirection = Vector3.Reflect(inDirection, inNormal).normalized;

        // Apply new direction * original speed * bounce force
        rb.velocity = collisionDirection * beforeSpeed * bounceForce;

        Debug.DrawRay(collision.contacts[0].point, inDirection * 2, Color.red, 2.0f); 
        Debug.DrawRay(collision.contacts[0].point, inNormal * 2, Color.green, 2.0f);
    }
}
