using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class ChangeColor : MonoBehaviour, ISpeechHandler {

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        setColor(eventData.RecognizedText);
    }

    public void setColor(string colorString)
    {

        GameObject[] carObjs = GameObject.FindGameObjectsWithTag("Lacken");
        Color color = new Color();
        switch (colorString)
        {
            case "color blue":
                color = Color.blue;
                break;
            case "color red":
                color = Color.red;
                break;
            case "color green":
                color = Color.green;
                break;
            case "color black":
                color = Color.black;
                break;
            case "color gray":
                color = Color.gray;
                break;
            case "show parts":
                color = Color.white;
                break;
            case "reset parts":
                color = Color.yellow;
                break;
            default:
                break;
        }   


        foreach(var component in carObjs)
        {
            component.GetComponent<MeshRenderer>().material.color = color;
        }

        
    }

}
