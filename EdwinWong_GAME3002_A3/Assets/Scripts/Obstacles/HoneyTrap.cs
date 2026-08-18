using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyTrap : MonoBehaviour
{
    float moveSpeedPenalty = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().SlowMoveSpeed();
            other.GetComponent<PlayerMovement>().moveSpeed -= 10;
            other.GetComponent<Rigidbody>().velocity /= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<PlayerMovement>().RestoreMoveSpeed();
        }
    }
}
