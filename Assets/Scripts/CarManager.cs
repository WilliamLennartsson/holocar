﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Academy
{
    public class CarManager : MonoBehaviour, ISpeechHandler 
    {
        private float expandAnimationCompletionTime;

        // Store a bool for whether our astronaut model is expanded or not.
        private bool isModelExpanding = false;

        private void Update()
        {
            if (isModelExpanding && Time.realtimeSinceStartup >= expandAnimationCompletionTime)
            {
                isModelExpanding = false;

                Animator[] expandedAnimators = ExpandModel.Instance.ExpandedModel.GetComponentsInChildren<Animator>();
                foreach (Animator animator in expandedAnimators)
                {
                    animator.enabled = false;
                }
            }
        }

        public void ResetModelCommand()
        {
            // Reset local variables.
            isModelExpanding = false;


            GameObject currentModel = ExpandModel.Instance.gameObject;
            GameObject expandedModel = ExpandModel.Instance.ExpandedModel;

            Animator anim = currentModel.GetComponent<Animator>();
            anim.Play("ResetCarAnimation");
            // Disable the expanded model.
            expandedModel.SetActive(false);

            // Enable the idle model.
            currentModel.SetActive(true);


            // Enable the animators for the next time the model is expanded.
            Animator[] expandedAnimators = expandedModel.GetComponentsInChildren<Animator>();
            foreach (Animator animator in expandedAnimators)
            {
                animator.enabled = true;
            }

            ExpandModel.Instance.Reset();
        }
        Animator anim;
        public void ExpandModelCommand()
        {
            // Swap out the current model for the expanded model.
            GameObject currentModel = ExpandModel.Instance.gameObject;
            GameObject expandedModel = ExpandModel.Instance.ExpandedModel;

            expandedModel.transform.position = currentModel.transform.position;
            expandedModel.transform.rotation = currentModel.transform.rotation;
            expandedModel.transform.localScale = currentModel.transform.localScale;

            currentModel.SetActive(false);
            expandedModel.SetActive(true);

            anim = expandedModel.GetComponent<Animator>();
            anim.Play("CarAnimation");

            // Play animation.  Ensure the Loop Time check box is disabled in the inspector for this animation to play it once.
            Animator[] expandedAnimators = expandedModel.GetComponentsInChildren<Animator>();
            // Set local variables for disabling the animation.
            if (expandedAnimators.Length > 0)
            {
                expandAnimationCompletionTime = Time.realtimeSinceStartup + expandedAnimators[0].runtimeAnimatorController.animationClips[0].length * 0.9f;
            }

            // Set the expand model flag.
            isModelExpanding = true;

            ExpandModel.Instance.Expand();
        }

        public void OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            Debug.Log("Inside CarManager");
            throw new System.NotImplementedException();
        }
    }
}