using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    void Start()
    {
        if (EndCanvas.instance.isCanvasTrue == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
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
            //playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            //player.transform.position = new Vector3(inputDir.x, player.position.y, inputDir.z);
            rb.AddForce(inputDir.normalized, ForceMode.Force);
        }
    }
}
