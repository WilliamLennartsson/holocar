using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GazeBehaviorBase : TransitionBehaviorBase, IFocusable {

    public bool focus = false;
    public void OnFocusEnter()
    {
        transitionIn();
        focus = true;
    }

    public void OnFocusExit()
    {
        transitionOut();
        focus = false;
    }
}
