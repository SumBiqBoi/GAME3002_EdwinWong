using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSave : MonoBehaviour
{
    public LinkedList<ShapeData> shapeSavedList = new LinkedList<ShapeData>();

    bool isStartTimer;
    
    void Start()
    {
        isStartTimer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShapeTracker")
        {
            isStartTimer = true;

            ShapeTracker shapeTracker = other.GetComponentInChildren<ShapeTracker>();

            if (shapeTracker != null)
            {
                foreach (ShapeData shapeData in shapeTracker.shapeList)
                {
                    shapeSavedList.AddLast(shapeData);
                }
            }
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