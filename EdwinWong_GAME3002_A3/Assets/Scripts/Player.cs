using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] float moveSpeed = 20;

    private Rigidbody rb;

    Vector3 movement = new Vector3(1.0f, 1.0f, 1.0f);

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        float horInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        rb.velocity = new Vector3(horInput, rb.velocity.y, verInput);

        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void FixedUpdate()
    {
        
    }
}
