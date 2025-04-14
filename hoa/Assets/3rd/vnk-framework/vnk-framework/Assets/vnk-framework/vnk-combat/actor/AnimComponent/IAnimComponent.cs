
using UnityEngine;

namespace Yoolax.Framework
{
    public interface IAnimComponent
    {
        Transform AnimationTransform { get; }
        void SetAnimation(string animationName, float speed, bool isLoop = false, float fadeDuration = 0.25f);
        void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25f);
        void SetAnimation(AnimationClip animationClip, float speed, bool isLoop = false, float fadeDuration = 0.25f, int layer = 0);
        void SetAvatarMask(int layer, AvatarMask avatarMask);
        void FlipX(bool value);
    }
}