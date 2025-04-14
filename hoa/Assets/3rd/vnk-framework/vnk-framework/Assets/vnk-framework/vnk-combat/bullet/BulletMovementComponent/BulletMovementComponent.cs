
namespace Yoolax.Framework
{
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BulletMovementComponent : BaseBulletComponent, IBulletMovementComponent
    {
        [SerializeField] private float speed = 15f;
        protected bool locked;
        protected Tween tween;
        public bool Locked { get => locked;}
        public float Speed { get => speed; set => speed = value; }

        public void Lock(bool _isLocked)
        {
            locked = _isLocked;
        }

        public Tween MoveTweeningBaseSpeed(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear)
        {
            tween = _bullet.Trans.DOMove(position, speed).OnComplete(onComplete).SetEase(easeType).SetSpeedBased();
            return tween;
        }

        public Tween MoveTweening(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear)
        {
            tween = _bullet.Trans.DOMove(position, speed).OnComplete(onComplete).SetEase(easeType);
            return tween;
        }
    }
}