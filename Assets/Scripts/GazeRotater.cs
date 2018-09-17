using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeRotater : GazeBehaviorBase {


    public float maxRotationSpeed = 40f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, maxRotationSpeed * transitionFactor * Time.deltaTime);

	}
}
