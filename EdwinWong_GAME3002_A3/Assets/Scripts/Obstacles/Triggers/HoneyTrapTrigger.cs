using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyTrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject palletPanel;
    [SerializeField] GameObject honey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            palletPanel.GetComponent<Rigidbody>().isKinematic = false;
            palletPanel.GetComponent<Rigidbody>().AddForce(Vector3.forward * -2, ForceMode.Impulse);

            honey.SetActive(true);
        }
    }
}
