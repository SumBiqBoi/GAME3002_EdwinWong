using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSave : MonoBehaviour
{
    [SerializeField] OpenDoor openDoor;
    
    [SerializeField] float setSaveTime;

    bool isStartTimer;

    float timerToSpawnShape;

    void Start()
    {
        isStartTimer = false;

        timerToSpawnShape = setSaveTime;
    }

    private void Update()
    {
        Debug.Log("Start timer: " + isStartTimer);
        Debug.Log("Timer To Spawn Shape = " + timerToSpawnShape);

        if (isStartTimer)
        {
            timerToSpawnShape -= Time.deltaTime;

            if (timerToSpawnShape < 0)
            {
                openDoor.OpenDoorAnimation();

                isStartTimer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStartTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStartTimer = false;

            timerToSpawnShape = setSaveTime;
        }
    }
}