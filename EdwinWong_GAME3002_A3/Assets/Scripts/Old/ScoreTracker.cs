using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            EndCanvas.instance.hasSphere = true;
            EndCanvas.instance.multiplierValue += 3;
        }
        if (other.gameObject.tag == "Capsule")
        {
            EndCanvas.instance.hasCapsule = true;
            EndCanvas.instance.multiplierValue += 2;
        }
        if (other.gameObject.tag == "Cube")
        {
            EndCanvas.instance.hasCube = true;
            EndCanvas.instance.multiplierValue += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            EndCanvas.instance.hasSphere = false;
            EndCanvas.instance.multiplierValue -= 3;
        }
        if (other.gameObject.tag == "Capsule")
        {
            EndCanvas.instance.hasCapsule = false;
            EndCanvas.instance.multiplierValue -= 2;
        }
        if (other.gameObject.tag == "Cube")
        {
            EndCanvas.instance.hasCube = false;
            EndCanvas.instance.multiplierValue -= 1;
        }
    }
}
