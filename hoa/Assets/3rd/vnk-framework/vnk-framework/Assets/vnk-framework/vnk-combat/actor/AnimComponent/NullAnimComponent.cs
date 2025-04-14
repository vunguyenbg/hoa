

using UnityEngine;

namespace Yoolax.Framework
{
    public class NullAnimComponent : BaseComponent, IAnimComponent
    {
        public Transform AnimationTransform { get; }

        public void SetAnimation(string animationName, float speed, bool isLoop = false, float normalizedTime = 0,
            bool isTriger = false)
        {
            throw new System.NotImplementedException();
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float normalizedTime = 0,
            bool isTriger = false)
        {
            throw new System.NotImplementedException();
        }

        public void FlipX(bool value)
        {
            throw new System.NotImplementedException();
        }

        public void SetAnimation(string animationName, float speed, bool isLoop = false, float fadeDuration = 0.25F)
        {
            throw new System.NotImplementedException();
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25F)
        {
            throw new System.NotImplementedException();
        }

        public void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25F, int layer = 0)
        {
            throw new System.NotImplementedException();
        }

        public void SetAvatarMask(int layer, AvatarMask avatarMask)
        {
            throw new System.NotImplementedException();
        }
    }
}