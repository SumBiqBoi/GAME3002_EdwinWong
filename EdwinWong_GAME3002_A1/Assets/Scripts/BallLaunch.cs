using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaunch : MonoBehaviour
{
    [SerializeField] GameObject oscillatingArrow;

    [SerializeField] Rigidbody rb;

    [SerializeField] public float launchSpeed;
    [SerializeField] public float launchSpeedMax;
    [SerializeField] public float launchAngleY;
    [SerializeField] public float launchAngleX;

    [SerializeField] float oscillateNumber;

    public float maxHeight;
    public float maxRange;
    public float airTime;
    public float score;

    public bool isAtStart;
    public bool hitBoard;
    bool oscillateFlip;
    bool horizontalAngle;
    bool verticalAngle;
    bool startTime;
    bool firstImpact;
    Vector3 startPosition;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        startPosition = new Vector3(0, 1.5f, 0);
        launchSpeed = 0.0f;
        launchSpeedMax = 30.0f;
        launchAngleY = 0.0f;
        launchAngleX = 0.0f;
        maxHeight = 0.0f;
        maxRange = 0.0f;
        airTime = 0.0f;
        score = 0;
        isAtStart = true;
        hitBoard = false;
        oscillateFlip = false;
        horizontalAngle = true;
        verticalAngle = false;
        startTime = false;
        firstImpact = false;
    }

    private void Update()
    {

        // Switch to vertical angle
        if (Input.GetKey(KeyCode.V))
        {
            horizontalAngle = false;
            verticalAngle = true;
            oscillateNumber = launchAngleY;
        }

        // Switch to horizontal angle
        if (Input.GetKey(KeyCode.H))
        {
            horizontalAngle = true;
            verticalAngle = false;
            oscillateNumber = launchAngleX;
        }

        // Locks angles
        if (Input.GetKey(KeyCode.L))
        {
            horizontalAngle = false;
            verticalAngle = false;
        }

        // Fire the ball
        if (isAtStart)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                LaunchBall();
                startTime = true;
            }
        }

        // Resets the ball
        if (Input.GetKey(KeyCode.R))
        {
            rb.velocity = Vector3.zero;
            transform.position = startPosition;
            oscillateNumber = 0;
            launchSpeed = 0;
            horizontalAngle = true;
            verticalAngle = false;
            hitBoard = false;
            startTime = false;
            firstImpact = false;
        }
    }

    void FixedUpdate()
    {
        if (startTime)
        {
            airTime += Time.deltaTime;
        }

        if (horizontalAngle)
        {
            Oscillate(-45, 45);
            oscillatingArrow.transform.rotation = Quaternion.Euler(launchAngleY, oscillateNumber, 0);
            launchAngleX = oscillateNumber;
        }

        if (verticalAngle)
        {
            Oscillate(-80, -5);
            oscillatingArrow.transform.rotation = Quaternion.Euler(oscillateNumber, launchAngleX, 0);
            launchAngleY = oscillateNumber;
        }

        // Set launch speed
        if (Input.GetKey(KeyCode.Space))
        {
            launchSpeed++;
            launchSpeed = Mathf.Clamp(launchSpeed, 10.0f, launchSpeedMax);
        }
        PhysicsCalculations();
    }

    void LaunchBall()
    {
        // Launch ball based on power and angle. Power and angle will determine the height and air time

        // Angles are calculated with Vx = V * cos(theta) and Vy = V * sin(theta)

        // launchAngleY uses Abs to make sure it's not launching on a negative angle (aka down)
        float angleY = Mathf.Abs(launchAngleY) * Mathf.Deg2Rad;
        float angleX = launchAngleX * Mathf.Deg2Rad;

        // x axis uses Sin(angleX) to calculate left right, y uses Sin(angleY) to calculate up down, z uses Sin(angleY) to calculate front
        rb.velocity = new Vector3(launchSpeed * Mathf.Sin(angleX), launchSpeed * Mathf.Sin(angleY), launchSpeed * Mathf.Cos(angleY));
    }

    // Lets the number oscillate between min and max. Allows the launch of the ball to be more interesting
    public void Oscillate(float min, float max)
    {
        if (!oscillateFlip)
        {
            oscillateNumber++;
            if (oscillateNumber > max)
            {
                oscillateFlip = true;
            }
        }
        else
        {
            oscillateNumber--;
            if (oscillateNumber < min)
            {
                oscillateFlip = false;
            }
        }
    }

    void PhysicsCalculations()
    {
        // H = V^2 * sin^2(theta) / (2 * g)
        maxHeight = (Mathf.Pow(launchSpeed, 2) * Mathf.Pow(Mathf.Sin(launchAngleY), 2)) / (2 * Physics.gravity.y);

        // R = 2 * V^2 * cos(theta) * sin(theta) / g
        //maxRange = (2 * Mathf.Pow(launchSpeed, 2) * Mathf.Cos(launchAngleY) * Mathf.Sin(launchAngleY)) / Physics.gravity.y;

        // T = 2 * V(initial) * sin(theta) / g
        //airTime = (2 * launchSpeed * Mathf.Sin(launchAngleY)) / Physics.gravity.y;
    }

    void UpdateScore(float scoreAdded)
    {
        score += scoreAdded;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            hitBoard = true;
            startTime = false;
        }

        if (!firstImpact)
        {
            maxRange = transform.position.z;
            firstImpact = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Start")
        {
            isAtStart = true;
        }
        if (other.tag == "100")
        {
            UpdateScore(100);
        }
        if (other.tag == "50")
        {
            UpdateScore(50);
        }
        if (other.tag == "25")
        {
            UpdateScore(25);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Start")
        {
            isAtStart = false;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    // Visual representation of oscillating angle to launch ball.
    //    //Gizmos.DrawRay(startPosition, new Vector3(2 * Mathf.Sin(oscillateNumber * Mathf.Deg2Rad), 0, 2 * Mathf.Cos(oscillateNumber * Mathf.Deg2Rad)));
    //}
}
