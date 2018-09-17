using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GazeBehaviorBase : TransitionBehaviorBase, IFocusable {
    


    public void OnFocusEnter()
    {
        transitionIn();
    }

    public void OnFocusExit()
    {
        transitionOut();
    }
}
