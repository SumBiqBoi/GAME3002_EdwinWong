using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20;

    private Rigidbody rb;

    Vector3 movement = new Vector3(1.0f, 1.0f, 1.0f);

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.forward * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
