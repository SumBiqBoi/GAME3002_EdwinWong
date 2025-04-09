using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPole : MonoBehaviour
{
    [SerializeField] private Vector3 torque;
    [SerializeField] private float speed;
    [SerializeField] private float maxOffsetX = 5f;
    [SerializeField] private float minOffsetX = -5f;

    private float defaultY = 0f;
    private float defaultZ = 0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;

        defaultY = transform.position.y;
        defaultZ = transform.position.z;
    }

    void Update()
    {
        // Ping pong the position so it moves from end to end
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxOffsetX - minOffsetX) + minOffsetX, defaultY, defaultZ);
    }

    private void FixedUpdate()
    {
        rb.AddTorque(torque);
    }
}
