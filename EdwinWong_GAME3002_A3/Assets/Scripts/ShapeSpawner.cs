using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    LinkedList<ShapeData> shapeSpawnList = new LinkedList<ShapeData>();

    [SerializeField] Transform shapeSpawnPosition;

    [SerializeField] float setSpawnTime;

    float timerToSpawnShape;

    bool isStartTimer;

    private void Start()
    {
        isStartTimer = false;

        timerToSpawnShape = setSpawnTime;
    }

    private void Update()
    {
        if (isStartTimer)
        {
            timerToSpawnShape -= Time.deltaTime;

            if (timerToSpawnShape < 0 )
            {
                foreach (ShapeData shapeData in shapeSpawnList)
                {
                    Instantiate(shapeData.shapePrefab, shapeSpawnPosition);
                }
                isStartTimer = false;
            }
        }

        Debug.Log("StartTimer: " + isStartTimer);
        Debug.Log("Shape timer: " +  timerToSpawnShape);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStartTimer = true;

            ShapeTracker shapeTracker = other.GetComponentInChildren<ShapeTracker>();

            Debug.LogWarning("Collision Name: " + other.name);

            if (shapeTracker != null)
            {
                Debug.LogWarning("ShapeTrackerList: " + shapeTracker.shapeList.Count);
                foreach (ShapeData shapeData in shapeTracker.shapeList)
                {
                    shapeSpawnList.AddLast(shapeData);
                    Debug.LogWarning("Shapes added to spawner list: " + shapeSpawnList.Count);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStartTimer = false;

            timerToSpawnShape = setSpawnTime;
        }
    }
}
