using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class BoundingBoxGaze : MonoBehaviour, IFocusable {

    public GameObject boundingBoxBasic;
    protected Renderer rend;

    public void OnFocusEnter()
    {
        rend.enabled = true;
        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        rend.enabled = false;
        throw new System.NotImplementedException();
    }

    void Start () {
        BoundingBox b = boundingBoxBasic.GetComponent<BoundingBox>();
        rend = b.GetComponentInChildren<Renderer>();
        rend.enabled = false;


    }

    void Update () {
		
	}
}
