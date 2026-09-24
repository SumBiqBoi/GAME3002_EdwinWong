using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    public Vector3 checkpointPos;
    Vector3 startingPos;

    Rigidbody rb;

    private void Start()
    {
        startingPos = transform.position;
        checkpointPos = startingPos;

        rb = GetComponentInParent<Rigidbody>();
    }

    public void ResetPlayerToCheckpoint()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = checkpointPos;
        rb.rotation = Quaternion.identity;
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
            ResetPlayerToCheckpoint();
        }

        if (other.gameObject.tag == "Finish")
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
