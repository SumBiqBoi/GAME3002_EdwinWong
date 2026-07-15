using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPole : MonoBehaviour
{
    [SerializeField] GameObject pole;
    [SerializeField] GameObject spinningObstacle;
    [SerializeField] Transform direction;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    [SerializeField] float moveSpeed;

    Vector3 startPosition;

    void Start()
    {
        startPosition = pole.transform.position;
    }

    void Update()
    {
        pole.transform.position += pole.transform.forward * moveSpeed * Time.deltaTime;

        float forwardDistanceFromStart = Vector3.Dot(pole.transform.position - startPosition, pole.transform.forward);

        Rebound(forwardDistanceFromStart);

        Debug.Log(forwardDistanceFromStart);
    }

    void Rebound(float distanceCheck)
    {
        if (distanceCheck > maxDistance)
        {
            moveSpeed = -Mathf.Abs(moveSpeed);
        }
        else if (distanceCheck < minDistance)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
        }
    }
}
