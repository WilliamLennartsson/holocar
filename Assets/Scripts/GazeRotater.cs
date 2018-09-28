using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.UX.ToolTips;

public class GazeRotater : GazeBehaviorBase
{

    Transform[] transformToRotate;
    public GameObject infoComponent;
    public string toolTipText = "Tool Tip goes here";

    public float maxRotationSpeed = 40f;
    // Use this for initialization
    void Start()
    {
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z);
        ToolTip tool = infoComponent.GetComponent<ToolTip>();
        tool.Anchor = gameObject;
        tool.ToolTipText = toolTipText;
        Instantiate(infoComponent, pos, Quaternion.identity);
        infoComponent.SetActive(false);
        
    }   

    // Update is called once per frame
    void Update()
    {

        transformToRotate = GetComponentsInChildren<Transform>();

        for (int i = 0; i < transformToRotate.Length; i++)
        {
            transformToRotate[i].Rotate(Vector3.up, maxRotationSpeed * transitionFactor * Time.deltaTime);
        }
    }
}

