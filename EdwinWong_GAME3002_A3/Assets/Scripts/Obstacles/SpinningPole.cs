using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPole : MonoBehaviour
{
    [SerializeField] GameObject pole;
    [SerializeField] GameObject spinningObstacle;
    [SerializeField] Transform direction;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    [SerializeField] float moveSpeed;

    float reboundMax;
    float reboundMin;

    void Start()
    {
        reboundMin = transform.position.x;
        reboundMax = maxDistance + pole.transform.localPosition.x;
    }

    void Update()
    {
        pole.transform.position = new Vector3(direction.position.x + (moveSpeed * Time.deltaTime), direction.position.y, direction.position.z);

        if (pole.transform.localPosition.x > reboundMax)
        {
            Rebound();
        }

        if (pole.transform.localPosition.x < reboundMin)
        {
            Rebound();
        }
    }

    void Rebound()
    {
        moveSpeed *= -1;
    }
}
