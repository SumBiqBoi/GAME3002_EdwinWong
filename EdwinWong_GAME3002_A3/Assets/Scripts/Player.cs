using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2;

    private Rigidbody rb;

    Vector3 movement;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += movement * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
