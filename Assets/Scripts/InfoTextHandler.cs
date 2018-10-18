using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;



public class InfoTextHandler : MonoBehaviour, IFocusable {
    GameObject textObj;
    MeshRenderer textRenderer;
    public string text;
    void Start () {
        textObj = GameObject.FindGameObjectWithTag("InfoText");
        textRenderer = textObj.GetComponentInChildren<MeshRenderer>();
        
        
    }

    void Update () {
		
	}

    public void OnFocusEnter()
    {
        
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

        textRenderer.enabled = true;
        textObj.transform.position = pos;
        TextMesh t = textObj.GetComponentInChildren<TextMesh>();
        t.text = text;

        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        textRenderer.enabled = false;
        throw new System.NotImplementedException();
    }
}
