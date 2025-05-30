using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject com;
    [SerializeField] GameObject cartBed;
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    public Vector3 checkpointPos;

    [SerializeField] Rigidbody rb;

    void Start()
    {
        rb.centerOfMass = com.transform.position;
    }

    void Update()
    {
        PlayerInput();

        Debug.Log(EndCanvas.instance.score);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("game");
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
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
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
