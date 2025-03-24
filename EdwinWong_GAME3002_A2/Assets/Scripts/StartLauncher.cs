using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLauncher : MonoBehaviour
{
    [SerializeField] private GameObject startLauncher;
    [SerializeField] private GameObject startPos;
    [SerializeField] private GameObject endPos;
    [SerializeField] private float powerAmount;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        powerAmount = 2f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Launcher();
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.isKinematic = false;
            StartCoroutine(WaitAndReset());
        }

        if (startLauncher.transform.position.z >= startPos.transform.position.z)
        {
            // Dampen hingejoint movement after launch
            rb.velocity = Vector3.zero;
        }

        if (startLauncher.transform.position.z <= endPos.transform.position.z)
        {
            // Stop moving launcher after it reaches certain position
            powerAmount = 0;
        }
    }

    private void Launcher()
    {
        // Move launcher back based on powerAmount
        startLauncher.transform.localPosition += -startLauncher.transform.forward * powerAmount * Time.deltaTime;
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(1.0f);
        startLauncher.transform.localPosition = new Vector3(0.0F, 3.5f, 0.0f);
        // Enable Kinematic so the hingejoint doesn't try to launch
        rb.isKinematic = true;
        powerAmount = 2;

        StopCoroutine(WaitAndReset());
    }
}
