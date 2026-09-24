using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject FreeLookCamera;
    float moveSpeed;
    float rotateSpeed;

    float slowSpeed;

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

        slowSpeed = ContentLoader.UpgradesStats().acceleration - 5; // 15

        rb.mass = ContentLoader.UpgradesStats().mass;

        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        playerTriggerCollision = GetComponentInChildren<PlayerTriggerCollision>();

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

        //Debug.Log("Velocity: " + rb.velocity.magnitude);
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
        ContentLoader.UpgradesStats().SubtractAcceleration(slowSpeed);
    }

    public void RestoreMoveSpeed()
    {
        ContentLoader.UpgradesStats().AddAcceleration(slowSpeed);
    }
}
