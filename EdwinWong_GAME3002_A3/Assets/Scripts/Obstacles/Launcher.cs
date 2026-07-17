using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] GameObject launcher;
    [SerializeField] float launchSpeed;
    [SerializeField] float stoppingDistance;

    Vector3 startPosition;
    Vector3 stoppingPoint;

    [SerializeField] bool canLaunch;

    void Start()
    {
        startPosition = launcher.transform.position;

        canLaunch = false;
    }

    void Update()
    {
        if (canLaunch)
        {
            Launch();
        }
    }

    void Launch()
    {
        launcher.transform.position += launcher.transform.forward * launchSpeed * Time.deltaTime;

        float forwardDistanceFromStart = Vector3.Dot(launcher.transform.position - startPosition, launcher.transform.forward);

        if (forwardDistanceFromStart > stoppingDistance)
        {
            launchSpeed = 0;
        }
    }

}
