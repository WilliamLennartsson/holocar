using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationScript : MonoBehaviour, ISpeechHandler {

    public Animator anim;
    private GameObject animatedCar;
    private GameObject notAnimatedCar;
    private bool isAnimating;
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        if (eventData.RecognizedText == "show parts")
        {
            triggerAnimation();
            Debug.Log("Triggered Potatis ");
        } else
        {

        }
        
        
    }
    public void resetAnimation()
    {
        anim.Play("ResetCarAnimation");    
    }
    public void swapCars()
    {
        //animatedCar.SetActive(false);
        //notAnimatedCar.SetActive(true);
    }
    public void triggerAnimation()
    {
        //animatedCar.SetActive(true);
        //notAnimatedCar.SetActive(false);
        anim.Play("CarAnimation");
    }
    // Use this for initialization
    void Start () {

        animatedCar = GameObject.FindGameObjectWithTag("AnimatedCar");
        notAnimatedCar = GameObject.FindGameObjectWithTag("Potatis");

        anim = animatedCar.GetComponent<Animator>();
        isAnimating = false;

    }
    void update()
    {

    }

}
