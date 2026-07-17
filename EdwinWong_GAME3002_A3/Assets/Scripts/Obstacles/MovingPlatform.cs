using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject movingPlatform;
    [SerializeField] GameObject endLocation;
    [SerializeField] float moveSpeed;

    Vector3 startPosition;

    Vector3 direction;
    float distance;

    void Start()
    {
        startPosition = movingPlatform.transform.position;

        direction = (endLocation.transform.position - movingPlatform.transform.position).normalized;
        distance = (movingPlatform.transform.position - endLocation.transform.position).magnitude;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        movingPlatform.transform.position += direction * moveSpeed * Time.deltaTime;

        float distanceFromStart = Vector3.Dot(movingPlatform.transform.position - startPosition, direction);

        Rebound(distanceFromStart);
    }

    void Rebound(float distanceCheck)
    {
        if (distanceCheck > distance)
        {
            moveSpeed = -Mathf.Abs(moveSpeed);
        }
        else if (distanceCheck < 0)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
        }
    }
}
