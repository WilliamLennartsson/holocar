using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class BoundingBoxGaze : MonoBehaviour, IFocusable {

    public GameObject boundingBoxBasic;
    protected Renderer rend;
    protected bool isActive = false;

    public void OnFocusEnter()
    {
        if (isActive)
        {
            rend.enabled = true;
        }
        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        if (isActive)
        {
            rend.enabled = false;
        }
        throw new System.NotImplementedException();
    }

    void Start () {
        BoundingBox b = boundingBoxBasic.GetComponent<BoundingBox>();
        rend = b.GetComponentInChildren<Renderer>();
        rend.enabled = false;


    }
    public void setActive()
    {
        isActive = true;
    }
    public void setInActive()
    {
        isActive = false;
        rend.enabled = false;
    }

    void Update () {
		
	}
}
