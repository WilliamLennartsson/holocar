using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionBehaviorBase : MonoBehaviour {
    
    [System.Serializable]

    public class TransitionOptions
    {
        [Tooltip("Amount in seconds to transition from 0 to 1")]
        public float transitionInDuration = 1f;

        [Tooltip("Amount in seconds to transition from 1 to 0")]
        public float transitionOutDuration = 1f;
    }

    public TransitionOptions transitionOption;

    protected float transitionFactor;

    private static readonly YieldInstruction EndOffFrame = new WaitForEndOfFrame();   

    public void transitionIn()
    {
        StopAllCoroutines();
        StartCoroutine(Coroutine_TransitionTo(0 , 1f, transitionOption.transitionInDuration));
    }   

    public void transitionOut()
    {
        StopAllCoroutines();
        StartCoroutine(Coroutine_TransitionTo(1f, 0, transitionOption.transitionOutDuration));
    }

    IEnumerator Coroutine_TransitionTo(float from, float to, float duration)
    {
        var rate = 1f / duration;
        var t = Mathf.InverseLerp(from, to, transitionFactor);

        while(t < 1)
        {
            transitionFactor = Mathf.Lerp(from, to, t);
            t += rate * Time.deltaTime;
            yield return EndOffFrame;
        }

        transitionFactor = to;
    }

}
