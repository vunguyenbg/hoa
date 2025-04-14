

namespace Yoolax.Framework
{
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class NullBulletMovementComponent : BaseBulletComponent, IBulletMovementComponent
    {
        protected bool locked;
        public bool Locked => locked;

        public float Speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Lock(bool _locked)
        {
            locked = _locked;
        }

        public Tween MoveTweening(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear)
        {
            throw new System.NotImplementedException();
        }

        public Tween MoveTweeningBaseSpeed(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear)
        {
            throw new System.NotImplementedException();
        }
    }
}