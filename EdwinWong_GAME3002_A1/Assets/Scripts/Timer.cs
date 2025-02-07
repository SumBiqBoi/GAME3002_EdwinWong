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

    // Quick timer that starts at 60 and subtracts until hits 0
    void Update()
    {
        remainingTime -= Time.deltaTime;
    }
}
