using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.UX.ToolTips;
using HoloToolkit.Unity.InputModule;

public class GazeRotater : GazeBehaviorBase
{
    
    Transform[] transformToRotate;
    Transform initPos;
    bool startedRotating = false;
    public float maxRotationSpeed = 40f;
    public GameObject boundingBox;
    protected BoundingBoxRig boundingBoxScript;
    protected GameObject target;
    protected BoundingBox bBox;

    void Start()
    {

    }

    void Update()
    {
        if (focus)
        {

            transformToRotate = GetComponentsInChildren<Transform>();

            for (int i = 0; i < transformToRotate.Length; i++)
            {
                transformToRotate[i].Rotate(Vector3.up, maxRotationSpeed * transitionFactor * Time.deltaTime);
            }

        } else if (!focus)
        {
            for (int i = 0; i < transformToRotate.Length; i++)
            {
                Quaternion root = transformToRotate[i].localRotation;
                root.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                transformToRotate[i].localRotation = root;
            }
        }
    }

}

