using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTorque : MonoBehaviour
{
    [SerializeField] private Vector3 vForce;
    [SerializeField] private Vector3 vCenterOfMass;
    [SerializeField] private Vector3 vForcePoint;

    private Vector3 torque;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;
    }

    void FixedUpdate()
    {
        // Get cross product between out force vector and the vector from the center of mass
        torque = Vector3.Cross(vForce, vForcePoint - vCenterOfMass);
        rb.AddTorque(torque);
    }

    public void OnAccelerate(Vector3 force)
    {
        vForce = Vector3.Lerp(vForce, force, Time.deltaTime);
    }
}
