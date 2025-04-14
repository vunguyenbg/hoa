
namespace Yoolax.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class MecAnimator : MonoBehaviour
    {
        private Animator animator;
        //[SerializeField] private bool disableOnStart;
        //[SerializeField] private bool disableComplete;
        //[SerializeField] private bool disableOnEvent;
        //public bool DisableOnStart { set => disableOnStart = value; get => disableOnStart; }
        //public bool DisableComplete { set => disableComplete = value; get => disableComplete; }
        //public bool DisableOnEvent { set => disableOnEvent = value; get => disableOnEvent; }

        private AnimationInfo animationInfo = new AnimationInfo();
        private EventInfo eventInfo = new EventInfo();
        public Action<AnimationInfo> onStart;
        public Action<AnimationInfo, EventInfo> onEvent;
        public Action<AnimationInfo> onComplete;
        private AnimationState animationState;
        private string OnStartValue = "OnStart";
        private string OnCompleteValue = "OnComplete";
        private string currentAnimation = string.Empty;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            AddEventToClip();
        }

        void AddEventToClip()
        {
            RuntimeAnimatorController ac = animator.runtimeAnimatorController;

            if (ac == null)
            {
                Debug.LogWarning("RuntimeAnimatorController is Null");
                return;
            }

            AnimationClip animationClip;
            for (int i = 0; i < ac.animationClips.Length; i++)
            {
                animationClip = ac.animationClips[i];
                animationClip.RemoveAnimationEvent(OnStartValue);
                animationClip.RemoveAnimationEvent(OnCompleteValue);

                animationClip.AddAnimationEvent(0, OnStartValue, animationClip.name);
                animationClip.AddAnimationEvent(animationClip.length, OnCompleteValue, animationClip.name);

            }
        }
        private void OnDisable()
        {
            RuntimeAnimatorController ac = animator.runtimeAnimatorController;

            if (ac == null)
            {
                Debug.LogWarning("RuntimeAnimatorController is Null");
                return;
            }
            AnimationClip animationClip;
            for (int i = 0; i < ac.animationClips.Length; i++)
            {
                animationClip = ac.animationClips[i];
                animationClip.RemoveAnimationEvent(OnStartValue);
                animationClip.RemoveAnimationEvent(OnCompleteValue);
            }
        }
        public void SetAnimation(string name, float normalizedTime = 0, bool isTrigger = false)
        {
            animationState = AnimationState.newAnimation;
            currentAnimation = name;
            if (isTrigger)
            {
                animator.SetTrigger(name);
            }
            else
            {
                animator.Play(name, 0, normalizedTime);
            }
        }
        public void OnStart(string _animationName)
        {
            if (animationState == AnimationState.newAnimation)
            {
                animationState = AnimationState.start;
                animationInfo.Init(_animationName);
                onStart?.Invoke(animationInfo);
            }
        }
        public void OnEvent(string _eventName)
        {
            eventInfo.Init(_eventName);
            onEvent?.Invoke(animationInfo, eventInfo);
        }
        public void OnComplete(string _animationName)
        {
            if (animationState == AnimationState.start)
            {
                if (currentAnimation.Equals(_animationName))
                {
                    animationState = AnimationState.complete;
                    animationInfo.Init(_animationName);
                    onComplete?.Invoke(animationInfo); 
                }
            }
        }
    }
}
