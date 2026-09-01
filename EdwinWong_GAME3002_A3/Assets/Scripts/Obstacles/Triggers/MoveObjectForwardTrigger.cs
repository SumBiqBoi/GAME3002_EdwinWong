using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectForwardTrigger : MonoBehaviour
{

    [SerializeField] Transform moveDirection;
    [SerializeField] GameObject moveObject;
    [SerializeField] GameObject[] triggers;

    Vector3 startPosition;

    Rigidbody rb;

    [SerializeField] float maxDistance;
    [SerializeField] float moveSpeed;

    [SerializeField] bool isChain = false;
    bool isMoving;

    [SerializeField] float delay = 0;

    private void Start()
    {
        foreach (GameObject trigger in triggers)
        {
            trigger.SetActive(false);
        }

        rb = moveObject.GetComponent<Rigidbody>();

        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (delay <= 0)
            {
                float forwardDistanceFromStart = Vector3.Dot(moveObject.transform.position - startPosition, moveDirection.forward);

                if (forwardDistanceFromStart < maxDistance)
                {
                    Vector3 moveForward = moveDirection.forward * moveSpeed * Time.deltaTime;
                    rb.MovePosition(moveObject.transform.position + moveForward);
                }
                else
                {
                    isMoving = false;
                }
                Debug.Log("is moving: " + isMoving);
                if (isChain)
                {
                    foreach (GameObject trigger in triggers)
                    {
                        trigger.SetActive(true);
                    }
                }
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startPosition = moveObject.transform.position;

            isMoving = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
