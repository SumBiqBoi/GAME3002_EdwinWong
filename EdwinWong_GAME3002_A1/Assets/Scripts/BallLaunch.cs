using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallLaunch : MonoBehaviour
{
    [SerializeField] GameObject oscillatingArrow;
    [SerializeField] Slider launchSpeedSlider;

    [SerializeField] Rigidbody rb;

    [SerializeField] public float launchSpeed;
    [SerializeField] public float launchSpeedMax;
    [SerializeField] public float launchAngleY;
    [SerializeField] public float launchAngleX;

    [SerializeField] float oscillateNumber;

    public float score;

    bool isAtStart;
    bool oscillateFlip;
    bool horizontalAngle;
    bool verticalAngle;
    Vector3 startPosition;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        startPosition = new Vector3(0, 1.5f, 0);
        launchSpeed = 0.0f;
        launchSpeedMax = 30.0f;
        launchAngleY = 0.0f;
        launchAngleX = 0.0f;
        oscillateFlip = false;
        horizontalAngle = true;
        verticalAngle = false;
        score = 0;
        isAtStart = true;
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
            }
        }

        // Resets the ball
        if (Input.GetKey(KeyCode.R))
        {
            horizontalAngle = true;
            verticalAngle = false;
            rb.velocity = Vector3.zero;
            transform.position = startPosition;
            oscillateNumber = 0;
            launchSpeed = 0;
        }
    }

    void FixedUpdate()
    {
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

    void UpdateScore(float scoreAdded)
    {
        score += scoreAdded;
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
