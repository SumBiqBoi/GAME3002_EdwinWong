using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;

    public Rigidbody rb;

    public float rotationSpeed;

    public float moveSpeed;

    void Start()
    {
        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        if (EndCanvas.instance.isCanvasTrue == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        // Rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        //
        //// Rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if (inputDir != Vector3.zero)
        {
            rb.AddForce(inputDir.normalized * moveSpeed, ForceMode.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rb.centerOfMass, 0.1f);
    }
}
