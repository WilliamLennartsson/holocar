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
        spinning = false;
        if (carAnimationRan || detailAnimationRan)
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

            toolTip.SetActive(false);

            for (int i = 0; i < gazeRotaters.Length; i++)
            {
                gazeRotaters[i].enabled = false;
                toolTipScripts[i].enabled = false;
            }
        }
    }

    public void swapCars()
    {
        spinning = false;
    }

    public void setSpinningTrue()
    {

        toolTip.SetActive(true);

        for (int i = 0; i < gazeRotaters.Length; i++)
        {
            gazeRotaters[i].enabled = true;
            toolTipScripts[i].enabled = true;
        }
        spinning = true;
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

    public GameObject[] spinningParts;
    void Start () {

        animatedCar = GameObject.FindGameObjectWithTag("AnimatedCar");
        notAnimatedCar = GameObject.FindGameObjectWithTag("Potatis");

        anim = animatedCar.GetComponent<Animator>();
        isAnimating = false;

        spinningParts = GameObject.FindGameObjectsWithTag("SpinningTag");

        gazeRotaters = GetComponentsInChildren<GazeRotater>();
        toolTipScripts = GetComponentsInChildren<SpawnToolTip>();

        toolTip = GameObject.FindGameObjectWithTag("ToolTip");
        toolTip.SetActive(false);

        //anim.Play("DetailAnimation");
        
    }
    void update()
    {

    }

}
