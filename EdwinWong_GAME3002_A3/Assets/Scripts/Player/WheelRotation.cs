
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody cartRb;
    [SerializeField] private float wheelRadius = 0.5f;

    private Quaternion previousCartRotation;

    private void Update()
    {
        // Linear movement of the cart.
        Vector3 linearVelocity = cartRb.velocity;

        // Measure the cart's rotation since the previous frame.
        Quaternion currentRotation = cartRb.rotation;
        Quaternion deltaRotation = currentRotation * Quaternion.Inverse(previousCartRotation);

        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        if (angle > 180f)
        {
            angle -= 360f;
        }

        // Approximate angular velocity in world space.
        Vector3 angularVelocity = axis * (angle * Mathf.Deg2Rad) / Mathf.Max(Time.deltaTime, 0.0001f);

        previousCartRotation = currentRotation;

        // Wheel movement = cart movement + turning movement.
        Vector3 wheelOffset = transform.position - cartRb.worldCenterOfMass;

        Vector3 rotationalVelocity = Vector3.Cross(angularVelocity, wheelOffset);

        Vector3 velocity = linearVelocity + rotationalVelocity;
        velocity.y = 0f;

        if (velocity.sqrMagnitude < 0.0001f)
            return;

        Vector3 rotationAxis = Vector3.Cross(Vector3.up, velocity.normalized);

        float distanceMoved = velocity.magnitude * Time.deltaTime;
        float rotationAngle = (distanceMoved / wheelRadius) * Mathf.Rad2Deg;

        transform.Rotate(rotationAxis, rotationAngle, Space.World);
    }
}


