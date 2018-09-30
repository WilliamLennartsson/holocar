using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationScript : MonoBehaviour, ISpeechHandler {

    private GazeRotater[] gazeRotaters;
    private SpawnToolTip[] toolTipScripts;
    public Animator anim;
    private GameObject animatedCar;
    private GameObject notAnimatedCar;
    private bool isAnimating;
    private bool spinning = true;
    public float speed = 5f;
    private bool detailAnimationRan = false;
    private bool carAnimationRan = false;
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

        if (carAnimationRan)
        {
            carAnimationRan = false;
            anim.Play("ResetCarAnimation");
        }
        else if (detailAnimationRan)
        {
            detailAnimationRan = false;
            // TODO: make animation for detail reset
        }
    }

    public void swapCars()
    {
        gazeRotaters = GetComponentsInChildren<GazeRotater>();
        toolTipScripts = GetComponentsInChildren<SpawnToolTip>();

        for (int i = 0; i < gazeRotaters.Length; i++)
        {
            gazeRotaters[i].enabled = false;
            toolTipScripts[i].enabled = false;
        }

        spinning = false;
        //animatedCar.SetActive(false);
        //notAnimatedCar.SetActive(true);
    }

    public void setSpinningTrue()
    {
        gazeRotaters = GetComponentsInChildren<GazeRotater>();
        toolTipScripts = GetComponentsInChildren<SpawnToolTip>();

        for (int i = 0; i < gazeRotaters.Length; i++)
        {
            gazeRotaters[i].enabled = true;
            toolTipScripts[i].enabled = true;

        }

        spinning = true;
    }

    public void triggerAnimation()
    {
        //animatedCar.SetActive(true);
        //notAnimatedCar.SetActive(false);
        carAnimationRan = true;
        anim.Play("CarAnimation");
    }

    public void triggerDetailAnimation()
    {
        detailAnimationRan = true;
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

        anim.Play("DetailAnimation");


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
