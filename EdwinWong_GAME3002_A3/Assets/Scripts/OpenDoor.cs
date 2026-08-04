using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator doorAnim;

    private void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void OpenDoorAnimation()
    {
        Debug.Log("Opening Door");

        doorAnim.Play("TutorialDoorsOpening");
    }
}
