using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloorBreaker")
        {
            BreakFloor();
        }
    }

    void BreakFloor()
    {
        gameObject.SetActive(false);
    }
}
