using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeRotater : GazeBehaviorBase {

    Transform[] transformToRotate;
    public float maxRotationSpeed = 40f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transformToRotate = GetComponentsInChildren<Transform>();
        for (int i = 0; i < transformToRotate.Length; i++)
        {
            transformToRotate[i].Rotate(Vector3.up, maxRotationSpeed * transitionFactor * Time.deltaTime);
        }
        //transform.Rotate(Vector3.up, maxRotationSpeed * transitionFactor * Time.deltaTime);
	}
}
