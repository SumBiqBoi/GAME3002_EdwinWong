using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSave : MonoBehaviour
{
    [SerializeField] OpenDoor openDoor;
    
    [SerializeField] float setSaveTime;
    
    public LinkedList<ShapeData> shapeSavedList = new LinkedList<ShapeData>();

    ShapeTracker shapeTracker;


    bool isStartTimer;

    float timerToSpawnShape;

    void Start()
    {
        isStartTimer = false;

        timerToSpawnShape = setSaveTime;
    }

    private void Update()
    {
        if (isStartTimer)
        {
            timerToSpawnShape -= Time.deltaTime;

            if (timerToSpawnShape < 0)
            {
                if (shapeTracker != null)
                {
                    foreach (ShapeData shapeData in shapeTracker.shapeList)
                    {
                        shapeSavedList.AddLast(shapeData);
                    }

                    openDoor.OpenDoorAnimation();
                }
                isStartTimer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShapeTracker")
        {
            isStartTimer = true;

            shapeTracker = other.GetComponentInChildren<ShapeTracker>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStartTimer = false;
        }
    }
}