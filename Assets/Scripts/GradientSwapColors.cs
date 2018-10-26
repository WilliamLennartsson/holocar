using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientSwapColors : GazeBehaviorBase {

    public Material mat1;
    public Material mat2;
    private Renderer renderer;
	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponentInChildren<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (focus)
        {
        renderer.material = mat2;
        } else
        {
            renderer.material = mat1;
        }
	}
}
