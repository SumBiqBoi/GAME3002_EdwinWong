using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springConstant;
    [SerializeField] private float dampeningConstant;
    [SerializeField] private float fMass;
    [SerializeField] private Vector3 restPos;
    [SerializeField] private Rigidbody attachedBody = null;

    private Vector3 vForce;
    private Vector3 vPrevVel;

    private void Start()
    {
        fMass = attachedBody.mass;
    }

    private void FixedUpdate()
    {
        UpdateSpringForce();
    }

    private void UpdateSpringForce()
    {
        vForce = -springConstant * ((restPos + transform.position) - attachedBody.transform.position) - dampeningConstant * (attachedBody.velocity - vPrevVel);
        attachedBody.AddForce(vForce, ForceMode.Acceleration);
        vPrevVel = attachedBody.velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(restPos + transform.position, 1f);

        if (attachedBody)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attachedBody.transform.position, 1f);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, attachedBody.transform.position);
        }
    }
}
