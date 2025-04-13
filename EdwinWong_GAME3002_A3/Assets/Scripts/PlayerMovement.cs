using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<SimpleTorque> wheelList;
    [SerializeField] private float maxAccelForce;
    [SerializeField] private float forceMultiplier;
    [SerializeField] private float forceDeceleration;

    [SerializeField] GameObject com;

    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Vector3 vForce;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com.transform.position;
    }

    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);

        foreach (SimpleTorque wheel in wheelList)
        {
            wheel.OnAccelerate(vForce + moveDirection.normalized * moveSpeed);
        }
    }
}
