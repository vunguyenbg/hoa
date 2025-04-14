using DG.Tweening;
using UnityEngine;

namespace Yoolax.Framework
{
    public interface IBulletMovementComponent
    {
        float Speed { set; get; }
        bool Locked { get;}
        void Lock(bool isLocked);
        Tween MoveTweeningBaseSpeed(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear);
        Tween MoveTweening(Vector3 position, TweenCallback onComplete = null, Ease easeType = Ease.Linear);
    }

}