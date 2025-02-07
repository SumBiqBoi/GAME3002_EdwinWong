using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float remainingTime;

    private void Start()
    {
        remainingTime = 60;    
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
    }
}
