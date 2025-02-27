using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float springConst = 0f;
    [SerializeField] private float originalPos = 0f;
    [SerializeField] private float pressedPos = 0f;
    [SerializeField] private float flipperSpringDamp = 0f;
    [SerializeField] private KeyCode flipperInput;

    private HingeJoint hJoint = null;
    private JointSpring jSpring;
    void Start()
    {
        hJoint = GetComponent<HingeJoint>();
        hJoint.useSpring = true;

        // JointSpring is used to add a spring force to HingeJoint

        jSpring = new JointSpring();
        jSpring.spring = springConst;
        jSpring.damper = flipperSpringDamp;
        // Pass values of our jointSpring to the hingeJoint's spring
        hJoint.spring = jSpring;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flipperInput))
        {
            OnFlipperPressed();
        }
        if (Input.GetKeyUp(flipperInput))
        {
            OnFlipperReleased();
        }
    }

    void OnFlipperPressed()
    {
        jSpring.targetPosition = pressedPos;
        hJoint.spring = jSpring;
    }

    void OnFlipperReleased()
    {
        jSpring.targetPosition = originalPos;
        hJoint.spring = jSpring;
    }
}
