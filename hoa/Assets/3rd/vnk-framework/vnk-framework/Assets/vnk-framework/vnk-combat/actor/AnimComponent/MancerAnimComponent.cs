
#if UNITY_ANIMANCER
namespace Yoolax.Framework
{
    using Sirenix.OdinInspector;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class MancerAnimComponent : BaseComponent, IAnimComponent, IListener
    {
        [SerializeField] private MancerAnimator mancerAnimator;

        public Transform AnimationTransform { get => mancerAnimator.transform; }

        public override void AwakeComponent(IActor actor)
        {
            base.AwakeComponent(actor);
          
        }

        public void OnAddListener(IActor actor)
        {
            ListenAnimState();
        }

        public void OnRemoveListener(IActor actor)
        {
            RemoveAnimState();
        }

        private void OnEvent(AnimationInfo _animationInfo, EventInfo _eventInfo)
        {
            actor.ActorAction.OnAnimationEvent?.Invoke(_animationInfo, _eventInfo);
        }
        private void OnComplete(AnimationInfo _animationInfo)
        {
            actor.ActorAction.OnAnimationComplete?.Invoke(_animationInfo);
        }
        public void ListenAnimState()
        {
            mancerAnimator.onComplete += OnComplete;
            mancerAnimator.onEvent += OnEvent;
        }

        public void RemoveAnimState()
        {
            mancerAnimator.onComplete -= OnComplete;
            mancerAnimator.onEvent -= OnEvent;
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25f)
        {
            mancerAnimator.SetAnimation(animationClip, speed, fadeDuration);
        }
        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25F, int layer = 0)
        {
            mancerAnimator.SetAnimation(animationClip, speed, fadeDuration, layer);
        }

        public void FlipX(bool value)
        {
            if (value)
            {
                mancerAnimator.transform.localScale = new Vector3(Mathf.Abs(mancerAnimator.transform.localScale.x), mancerAnimator.transform.localScale.y, mancerAnimator.transform.localScale.z);
            }
            else
            {
                mancerAnimator.transform.localScale = new Vector3(-Mathf.Abs(mancerAnimator.transform.localScale.x), mancerAnimator.transform.localScale.y, mancerAnimator.transform.localScale.z);
            }
        }

        public void SetAnimation(string animationName , float speed, bool isLoop = false, float fadeDuration = 0.25f)
        {
            mancerAnimator.SetAnimation(animationName, speed, fadeDuration);
        }

        public void SetAvatarMask(int layer, AvatarMask avatarMask)
        {
            mancerAnimator.SetAvatarMask(layer, avatarMask);
        }
    }

}
#endif