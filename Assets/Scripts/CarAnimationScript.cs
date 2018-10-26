using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;

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
    TwoHandManipulatable twoHanScript;
    Transform[] defaultTransforms;

    List<Vector3> originalPos = new List<Vector3>();
    List<Vector3> originalRotation = new List<Vector3>();


    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        if (eventData.RecognizedText == "show parts")
        {
            triggerAnimation();
            Debug.Log("Triggered Potatis ");
        }
    }

    public void resetAnimation()
    {
        
        for (int i = 0; i < defaultTransforms.Length; i++)
        {
            defaultTransforms[i].position = originalPos[i];

            Quaternion root = defaultTransforms[i].localRotation;
            root.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            defaultTransforms[i].localRotation = root;
            
        }
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
            gazeRotaters[i].resetRotation();
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
        defaultTransforms = GetComponentsInChildren<Transform>();
        //if (carAnimationRan) { return; }
        
        for (int i = 0; i < defaultTransforms.Length; i++)
        {
            Vector3 pos = defaultTransforms[i].position;
            originalPos.Add(pos);
        }

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
        //twoHanScript.enabled = false;
        anim.Play("CarAnimation");
    }

    public void triggerDetailAnimation()
    {
        detailAnimationRan = true;
        //twoHanScript.enabled = false;
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
            for (int i = 0; i < defaultTransforms.Length; i++)
            {
                Quaternion root = defaultTransforms[i].localRotation;
                root.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                defaultTransforms[i].localRotation = root;
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
        twoHanScript = GetComponent<TwoHandManipulatable>();

        //toolTip = GameObject.FindGameObjectWithTag("ToolTip");
        //toolTip.SetActive(false);
        //triggerAnimation();
        //triggerDetailAnimation();
        
    }

}
