using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject FreeLookCamera;
    public float moveSpeed;
    public float rotateSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    public Vector3 checkpointPos;

    [SerializeField] Rigidbody rb;

    void Start()
    {
        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        if (EndCanvas.instance.isCanvasTrue == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("game");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y - rotateSpeed * Time.deltaTime, player.transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.E))
        {
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y + rotateSpeed * Time.deltaTime, player.transform.eulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.transform.position = checkpointPos;
            player.transform.eulerAngles = new Vector3(-90, 0, 0);
        }
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
        // Rotate orientation
        Vector3 viewDir = player.transform.position - new Vector3(FreeLookCamera.transform.position.x, player.transform.position.y, FreeLookCamera.transform.position.z);
        orientation.forward = viewDir.normalized;

        // Move player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        Vector3 movementForce = inputDir.normalized * moveSpeed;

        float rotX = player.transform.rotation.eulerAngles.x;
        float rotZ = player.transform.rotation.eulerAngles.z;

        if (rotX >= 180)
        {
            rotX -= 360;
        }

        if (rotZ >= 180)
        {
            rotZ -= 360;
        }

        Vector3 inclineRot = new Vector3(Mathf.Abs(rotX), 0, Mathf.Abs(rotZ));

        if (inputDir != Vector3.zero)
        {
            if (inclineRot.x > 10 || inclineRot.z > 10)
            {
                if (inclineRot.x > inclineRot.z)
                {
                    moveSpeed += (inclineRot.x / 90);
                }
                else
                {
                    moveSpeed += (inclineRot.z / 90);
                }
            }
            else
            {
                if (moveSpeed > 20)
                {
                    moveSpeed -= 0.2f;
                }
                else
                {
                    moveSpeed = 20;
                }
            }

            rb.AddForce(movementForce, ForceMode.Acceleration);
        }
        else
        {
            if (moveSpeed > 20)
            {
                moveSpeed -= 0.2f;
            }
            else
            {
                moveSpeed = 20;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            Checkpoint checkpoint = other.GetComponent<Checkpoint>();
            checkpointPos = checkpoint.spawnLocation.transform.position;
        }

        if (other.gameObject.tag == "Killbox")
        {
            player.transform.position = checkpointPos;
            player.transform.eulerAngles = new Vector3(-90, 0, 0);
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            rb.freezeRotation = false;
        }

        if (other.gameObject.tag == "Finish")
        {
            Time.timeScale = 0f;
            EndCanvas.instance.endCanvas.SetActive(true);
            EndCanvas.instance.isCanvasTrue = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
