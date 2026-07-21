using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    LinkedList<ShapeData> shapeSpawnList = new LinkedList<ShapeData>();

    ShapeSave shapeSave;

    [SerializeField] Transform shapeSpawnPosition;
    [SerializeField] float setSpawnTime;

    Quaternion spawnRotation;

    float timerToSpawnShape;

    bool isStartTimer;

    private void Start()
    {
        shapeSave = FindObjectOfType<ShapeSave>();

        spawnRotation = Quaternion.identity;

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
                    GameObject newShape = Instantiate(shapeData.shapePrefab, shapeSpawnPosition.position,spawnRotation);
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

            if (shapeSave != null)
            {
                if (shapeSave.shapeSavedList.Count > shapeSpawnList.Count)
                {
                    shapeSpawnList.Clear();

                    foreach (ShapeData shapeData in shapeSave.shapeSavedList)
                    {
                        shapeSpawnList.AddLast(shapeData);
                    }
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
