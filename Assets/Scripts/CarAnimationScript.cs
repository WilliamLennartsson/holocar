using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationScript : MonoBehaviour, ISpeechHandler {

    public Animator anim;
    private GameObject animatedCar;
    private GameObject notAnimatedCar;
    private bool isAnimating;
    private bool spinning = true;
    public float speed = 5f;
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
        spinning = false;
        anim.Play("ResetCarAnimation");    
    }

    public void swapCars()
    {
        //animatedCar.SetActive(false);
        //notAnimatedCar.SetActive(true);
    }

    public void setSpinningTrue()
    {
        spinning = true;
    }

    public void triggerAnimation()
    {
        //animatedCar.SetActive(true);
        //notAnimatedCar.SetActive(false);
        anim.Play("CarAnimation");
    }

    public void triggerDetailAnimation()
    {
        anim.Play("DetailAnimation");
    }
    // Use this for initialization
    public GameObject[] spinningParts;
    void Start () {

        animatedCar = GameObject.FindGameObjectWithTag("AnimatedCar");
        notAnimatedCar = GameObject.FindGameObjectWithTag("Potatis");

        anim = animatedCar.GetComponent<Animator>();
        isAnimating = false;

        spinningParts = GameObject.FindGameObjectsWithTag("SpinningTag");

    }
    void update()
    {
        if (spinning)
        {
            foreach (GameObject part in spinningParts)
            {
                part.transform.Rotate(Vector3.up, speed * Time.deltaTime);
                
            }
       
        }
    }

}
