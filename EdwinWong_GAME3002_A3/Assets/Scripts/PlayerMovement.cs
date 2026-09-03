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
    float minMoveSpeed;
    float maxMoveSpeed;

    public Transform orientation;

    public Vector3 checkpointPos;
    Vector3 startingPos;

    float horizontalInput;
    float verticalInput;

    Vector3 inputDir;
    Vector3 movementForce;

    Vector3 inclineRot;
    float minClimbAngle;
    float rotX;
    float rotZ;
    float halfCircleAngle;
    float fullCircleAngle;

    [SerializeField] Rigidbody rb;

    void Start()
    {
        minMoveSpeed = moveSpeed;
        maxMoveSpeed = 45f;

        minClimbAngle = 10f;
        halfCircleAngle = 180f;
        fullCircleAngle = 360f;

        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        startingPos = transform.position;
        checkpointPos = startingPos;

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
            ResetPlayerToCheckpoint();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        inclineRot = PlayerCartAngleOnIncline(rotX, rotZ, inclineRot);

        if (inputDir != Vector3.zero)
        {
            if (inclineRot.x > minClimbAngle || inclineRot.z > minClimbAngle)
            {
                IncreaseMoveSpeedBasedOnAngle();
            }
            else
            {
                DecreaseMoveSpeed();
            }

            rb.AddForce(movementForce, ForceMode.Acceleration);
        }
        else
        {
            DecreaseMoveSpeed();
        }
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

        inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        movementForce = inputDir.normalized * moveSpeed;
    }

    void IncreaseMoveSpeedBasedOnAngle()
    {
        if (inclineRot.x > inclineRot.z)
        {
            moveSpeed += (inclineRot.x / 90);
        }
        else
        {
            moveSpeed += (inclineRot.z / 90);
        }

        moveSpeed = Mathf.Clamp(moveSpeed, minMoveSpeed, maxMoveSpeed);
    }

    void DecreaseMoveSpeed()
    {
        if (moveSpeed > minMoveSpeed)
        {
            moveSpeed -= 0.3f;
        }
        else
        {
            moveSpeed = minMoveSpeed;
        }
    }

    public void SlowMoveSpeed()
    {
        minMoveSpeed -= 10;
        maxMoveSpeed -= 10;
    }

    public void RestoreMoveSpeed()
    {
        minMoveSpeed += 10;
        maxMoveSpeed += 10;
    }

    Vector3 PlayerCartAngleOnIncline(float rotX, float rotZ, Vector3 inclineRot)
    {
        rotX = player.transform.rotation.eulerAngles.x;
        rotZ = player.transform.rotation.eulerAngles.z;

        rotX = FindRotationAngleAxis(rotX);
        rotZ = FindRotationAngleAxis(rotZ);

        return inclineRot = new Vector3(Mathf.Abs(rotX), 0, Mathf.Abs(rotZ));
    }

    float FindRotationAngleAxis(float axis)
    {
        if (axis >= halfCircleAngle)
        {
            axis -= fullCircleAngle;
        }

        return axis;
    }

    void ResetPlayerToCheckpoint()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = checkpointPos;
        rb.rotation = Quaternion.identity;
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
            ResetPlayerToCheckpoint();
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
