using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject FreeLookCamera;
    float moveSpeed;
    float rotateSpeed;
    float minMoveSpeed;
    float maxMoveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 inputDir;
    Vector3 movementForce;

    [SerializeField] Rigidbody rb;
    PlayerTriggerCollision playerTriggerCollision;

    void Start()
    {
        moveSpeed = ContentLoader.UpgradesStats().acceleration;
        rotateSpeed = ContentLoader.UpgradesStats().rotateSpeed;

        rb.mass = ContentLoader.UpgradesStats().mass;

        minMoveSpeed = moveSpeed;
        maxMoveSpeed = 45f;

        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        playerTriggerCollision = GetComponentInChildren<PlayerTriggerCollision>();

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
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerTriggerCollision.ResetPlayerToCheckpoint();
        }

        Debug.Log("Velocity: " + rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();

        rb.AddForce(movementForce, ForceMode.Acceleration);
        //Debug.Log("Velocity: " + rb.velocity.magnitude);
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Camera orientation
        Vector3 viewDir = player.transform.position - new Vector3(FreeLookCamera.transform.position.x, player.transform.position.y, FreeLookCamera.transform.position.z);
        orientation.forward = viewDir.normalized;

        inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        movementForce = PlayerRotationWithSlope(inputDir) * moveSpeed;
    }

    private Vector3 PlayerRotationWithSlope(Vector3 inputDir)
    {
        Vector3 groundNormal = player.transform.up;

        Vector3 slopeDir = Vector3.ProjectOnPlane(inputDir, groundNormal).normalized;

        return slopeDir;
    }

    private void RotatePlayer()
    {
        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationInput = 1f;
        }

        if (rotationInput != 0f)
        {
            float rotationAmount = rotationInput * rotateSpeed * Time.fixedDeltaTime;

            Quaternion rotation = rb.rotation * Quaternion.Euler(0f, rotationAmount, 0f);

            rb.MoveRotation(rotation);
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
}
