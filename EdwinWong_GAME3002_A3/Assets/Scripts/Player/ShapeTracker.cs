using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeTracker : MonoBehaviour
{
    public LinkedList<ShapeData> shapeList = new LinkedList<ShapeData>();

    private void OnTriggerEnter(Collider other)
    {
        ShapeData shapeData = other.GetComponent<ShapeData>();

        if (shapeData != null)
        {
            shapeList.AddLast(shapeData);

            Debug.Log("Shapes added to list: " + shapeList.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShapeData shapeData = other.GetComponent<ShapeData>();

        if (shapeData != null)
        {
            shapeList.Remove(shapeData);

            Debug.Log("Shapes removed from list: " + shapeData.shapePrefab.name);
        }
    }
}
