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
            foreach (GameObject go in gameObjects)
            {
                float forwardDistanceFromStart = Vector3.Dot(go.transform.position - startPosition, go.transform.forward);

                if (forwardDistanceFromStart < maxDistance)
                {
                    //Vector3 moveForward = go.transform.forward * moveSpeed * Time.deltaTime;
                    rb.MovePosition(new Vector3(go.transform.position.x + moveSpeed * Time.deltaTime, go.transform.position.y, go.transform.position.z));
                }
                else
                {
                    isMoving = false;
                }
            }
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
