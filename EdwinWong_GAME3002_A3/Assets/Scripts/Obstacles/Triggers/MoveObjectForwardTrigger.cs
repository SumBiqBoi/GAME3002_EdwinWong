using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectForwardTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;

    Vector3 startPosition;

    Rigidbody rb;

    [SerializeField] float maxDistance;
    [SerializeField] float moveSpeed;

    bool isMoving;

    [SerializeField] float delay = 0;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();

        foreach (GameObject go in gameObjects)
        {
            startPosition = go.transform.position;
        }

        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (delay <= 0)
            {
                foreach (GameObject go in gameObjects)
                {
                    float forwardDistanceFromStart = Vector3.Dot(go.transform.position - startPosition, go.transform.forward);

                    if (forwardDistanceFromStart < maxDistance)
                    {
                        Vector3 moveForward = go.transform.forward * moveSpeed * Time.deltaTime;
                        rb.MovePosition(go.transform.position + moveForward);
                    }
                    else
                    {
                        isMoving = false;
                    }
                }
            }
            else
            {
                delay -= Time.deltaTime;
            }

            Debug.Log("Delay" + delay);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isMoving = true;
        }
    }
}
