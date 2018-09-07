using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MoveCar : MonoBehaviour, ISpeechHandler {

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        updateCar(eventData.RecognizedText);
    }

    public void updateCar(string command)
    {
        switch (command)
        {
            case "move forward":
                transform.position += Vector3.forward * 1f;
                break;
            case "move back":
                transform.position += Vector3.back * 1f;
                break;
            case "move left":
                transform.position += Vector3.left * 1f;
                break;
            case "move right":
                transform.position += Vector3.right * 1f;
                break;
           
        }
    }

}
