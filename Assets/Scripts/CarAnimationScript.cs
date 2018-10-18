using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationScript : MonoBehaviour, ISpeechHandler {

    private GazeRotater[] gazeRotaters;
    private SpawnToolTip[] toolTipScripts;
    private InfoTextHandler[] infoTextHandlers;
    private BoundingBoxGaze[] boundingBoxGazers;
    public Animator anim;
    private GameObject animatedCar;
    private GameObject notAnimatedCar;
    private bool isAnimating;
    private bool spinning = false;
    public float speed = 5f;
    private bool detailAnimationRan = false;
    private bool carAnimationRan = false;
    GameObject toolTip;

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
        if (carAnimationRan)
        {
            carAnimationRan = false;
            anim.Play("ResetCarAnimation");
        }
        else if (detailAnimationRan)
        {
            detailAnimationRan = false;
            anim.Play("ResetDetailAnimation2");
        }
    }


    public void swapCars()
    {
        spinning = false;
        for (int i = 0; i < gazeRotaters.Length; i++)
        {
            //gazeRotaters[i].resetRotation();
            gazeRotaters[i].enabled = false;
        }

        for (int i = 0; i < infoTextHandlers.Length; i++)
        {
            infoTextHandlers[i].enabled = false;
        }
        for (int i = 0; i < boundingBoxGazers.Length; i++)
        {
            boundingBoxGazers[i].setInActive();
        }
    }

    public void setSpinningTrue()
    {

        for (int i = 0; i < infoTextHandlers.Length; i++)
        {
            infoTextHandlers[i].enabled = true;
        }

        for (int i = 0; i < gazeRotaters.Length; i++)
        {
            gazeRotaters[i].enabled = true;
        }

        for (int i = 0; i < boundingBoxGazers.Length; i++)
        {
            boundingBoxGazers[i].setActive();
        }

        spinning = true;
        //resetAnimation();
    }

    public void triggerAnimation()
    {
        carAnimationRan = true;
        anim.Play("CarAnimation");
    }

    public void triggerDetailAnimation()
    {
        detailAnimationRan = true;
        anim.Play("DetailAnimation");
    }

    public void editParts()
    {
        if (spinning)
        {
            for (int i = 0; i < gazeRotaters.Length; i++)
            {
                gazeRotaters[i].enabled = false;
            }
        }
    }

    public GameObject[] spinningParts;
    void Start () {

        animatedCar = GameObject.FindGameObjectWithTag("AnimatedCar");
        notAnimatedCar = GameObject.FindGameObjectWithTag("Potatis");

        anim = animatedCar.GetComponent<Animator>();
        isAnimating = false;

        spinningParts = GameObject.FindGameObjectsWithTag("SpinningTag");

        gazeRotaters = GetComponentsInChildren<GazeRotater>();
        toolTipScripts = GetComponentsInChildren<SpawnToolTip>();
        infoTextHandlers = GetComponentsInChildren<InfoTextHandler>();
        boundingBoxGazers = GetComponentsInChildren<BoundingBoxGaze>();

        //toolTip = GameObject.FindGameObjectWithTag("ToolTip");
        //toolTip.SetActive(false);
        //triggerAnimation();
        //triggerDetailAnimation(); Systen.out.println("en riktig bror");

        Systemout.printlm("kakkka haaaa bror");

    }

}
