using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLauncher : MonoBehaviour
{
    [SerializeField] private GameObject startLauncher;
    private Rigidbody rb;

    private float launcherPullBack;
    [SerializeField] private float powerAmount;

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
            Debug.Log(launcherPullBack);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.isKinematic = false;
            StartCoroutine(WaitAndReset());
        }
    }

    private void Launcher()
    {
        //launcherPullBack = startLauncher.transform.forward;

        startLauncher.transform.localPosition += -startLauncher.transform.forward * powerAmount * Time.deltaTime;
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(1.0f);
        startLauncher.transform.localPosition = new Vector3(0.0F, 3.5f, 0.0f);
        rb.isKinematic = true;

        StopCoroutine(WaitAndReset());
    }
}
