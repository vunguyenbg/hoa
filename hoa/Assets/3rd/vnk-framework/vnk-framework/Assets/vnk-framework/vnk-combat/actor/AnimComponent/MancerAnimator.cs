#if UNITY_ANIMANCER
using Animancer;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Animancer.AnimancerComponent))]
    public class MancerAnimator : MonoBehaviour
    {
        private Animancer.AnimancerComponent anim;
        [ShowInInspector] private Dictionary<string, AnimationClip> animationClips;
        public Action<AnimationInfo, EventInfo> onEvent;
        public Action<AnimationInfo> onComplete;

        private AnimationInfo animationInfo = new AnimationInfo();
        private EventInfo eventInfo = new EventInfo();

        private Animancer.AnimancerState animancerState;
        private AnimationClip animationClip;

        [SerializeField] private bool isGetAllAnimationToDictionary = true;

        private void Awake()
        {
            anim = GetComponent<AnimancerComponent>();
            if (isGetAllAnimationToDictionary)
            {
                animationClips = new Dictionary<string, AnimationClip>();
                AnimationClip animationClip = null;
                for (int i = 0; i < anim.Animator.runtimeAnimatorController.animationClips.Length; i++)
                {
                    animationClip = anim.Animator.runtimeAnimatorController.animationClips[i];
                    animationClips.Add(animationClip.name, animationClip);
                }
            }
        }


        public void SetAnimation(AnimationClip animationClip, float speed, float fadeDuration)
        {
            animationInfo.Init(animationClip.name);
            
            animancerState = anim.Play(animationClip, fadeDuration);
            animancerState.Speed = speed;
            animancerState.Events.OnEnd += OnEndAnimation;
        }
        public void SetAnimation(AnimationClip animationClip, float speed, float fadeDuration, int layer)
        {
            animationInfo.Init(animationClip.name);

            animancerState = anim.Layers[layer].Play(animationClip, fadeDuration);
            animancerState.Speed = speed;
            animancerState.Events.OnEnd += OnEndAnimation;
        }
        public void SetAnimation(string animationName, float speed, float fadeDuration)
        {
            animationInfo.Init(animationName);
            animationClip = animationClips[animationName];
            animancerState = anim.Play(animationClip, fadeDuration);
            animancerState.Speed = speed;
            animancerState.Events.OnEnd += OnEndAnimation;
        }
        public void SetAvatarMask(int layer, AvatarMask avatarMask)
        {
            anim.Layers[layer].SetMask(avatarMask);
        }
        public void OnEvent(string eventName)
        {
            eventInfo.Init(eventName);
            onEvent?.Invoke(animationInfo, eventInfo);
        }
        private void OnEndAnimation()
        {
            animancerState.Events.OnEnd -= OnEndAnimation;
            onComplete?.Invoke(animationInfo);
        }
    }

}
#endif
