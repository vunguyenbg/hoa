
namespace Yoolax.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MecAnimComponent : BaseComponent, IAnimComponent, IListener
    {
        [SerializeField]
        private MecAnimator _anim;
        //private AnimationInfo animationInfo = new AnimationInfo();

        public Transform AnimationTransform { get => _anim.transform; }

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
            _anim.onComplete += OnComplete;
            _anim.onEvent += OnEvent;
        }

        public void RemoveAnimState()
        {
            _anim.onComplete -= OnComplete;
            _anim.onEvent -= OnEvent;
        }


        public void FlipX(bool value)
        {
            if (value)
            {
                actor.Trans.localScale = new Vector3(Mathf.Abs(actor.Trans.localScale.x), actor.Trans.localScale.y, actor.Trans.localScale.z);
            }
            else
            {
                actor.Trans.localScale = new Vector3(-Mathf.Abs(actor.Trans.localScale.x), actor.Trans.localScale.y, actor.Trans.localScale.z);
            }
        }

       public void SetAnimation(string animationName, float speed, bool isLoop = false, float normalizedTime = 0, bool isTrigger = false)
        {
            _anim.SetAnimation(animationName, normalizedTime, isTrigger);
        }
       public void SetAnimation(AnimationClip animationClip, float speed, float fadeDuration = 0.25f)
       {
           // _anim.SetAnimation(animationName, normalizedTime, isTrigger);
           Debug.LogError("Mecanim Not support this method");
       }

        public void SetAnimation(string animationName, float speed, bool isLoop = false, float fadeDuration = 0.25F)
        {
            throw new NotImplementedException();
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25F)
        {
            throw new NotImplementedException();
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25F, int layer = 0)
        {
            throw new NotImplementedException();
        }

        public void SetAvatarMask(int layer, AvatarMask avatarMask)
        {
            throw new NotImplementedException();
        }
    }

}