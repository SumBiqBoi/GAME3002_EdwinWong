using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] Shapes shapeType;
    [SerializeField] Transform shapeSpawnPosition;
    [SerializeField] float setSpawnTime;

    Quaternion spawnRotation;

    float timerToSpawnShape;

    bool isStartTimer;

    private void Start()
    {
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
                GameObject newShape = Instantiate(SpawnShape(shapeType), shapeSpawnPosition.position,spawnRotation);

                isStartTimer = false;
            }
        }
    }

    GameObject SpawnShape(Shapes shape)
    {
        GameObject shapeToSpawn = null;

        if (shape == Shapes.Cube)
        {
            shapeToSpawn = Resources.Load<GameObject>("Cube- Transport");
        }
        else if (shape == Shapes.Capsule)
        {
            shapeToSpawn = Resources.Load<GameObject>("Capsule- Transport");
        }
        else if (shape == Shapes.Sphere)
        {
            shapeToSpawn = Resources.Load<GameObject>("Sphere- Transport");
        }
        
        return shapeToSpawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShapeTracker")
        {
            isStartTimer = true;
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
