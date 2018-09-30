using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.UX.ToolTips;



public class SpawnToolTip : MonoBehaviour, IFocusable {

    public GameObject infoComponent;
    public string toolTipText = "Tool Tip goes here";
    Vector3 partPos;

    public void OnFocusEnter()
    {

        //        infoComponent.SetActive(true);
        ToolTip tool = infoComponent.GetComponent<ToolTip>();

        tool.MasterTipState = TipDisplayModeEnum.On;
        tool.Anchor = gameObject;
        tool.ToolTipText = toolTipText;

        ToolTipConnector connector = infoComponent.GetComponent<ToolTipConnector>();
        infoComponent.transform.position = partPos;

        connector.Target = gameObject;

        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        ToolTip tool = infoComponent.GetComponent<ToolTip>();

        tool.MasterTipState = TipDisplayModeEnum.Off;
        throw new System.NotImplementedException();
    }
    // Use this for initialization
    void Start() {
        Vector3 objPos = gameObject.transform.position;
        Vector3 pos = new Vector3(objPos.x, objPos.y + 0.3f, objPos.z);
        partPos = pos;
        ToolTip tool = infoComponent.GetComponent<ToolTip>();

        tool.Anchor = gameObject;
        tool.ToolTipText = toolTipText;
        //tool.MasterTipState = TipDisplayModeEnum.On;

    }

    // Update is called once per frame
    void Update() {

    }
}

