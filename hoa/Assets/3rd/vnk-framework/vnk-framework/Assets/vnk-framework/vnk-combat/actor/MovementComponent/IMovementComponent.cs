using DG.Tweening;
using System;
using UnityEngine;

namespace Yoolax.Framework
{
    public interface IMovementComponent
    {
        float Speed { set; get; }
        bool IsLocked { get; set; }
        bool Freeze { get; set; }

        void Move(Vector3 direction);
        void RotateTowards(Vector3 worldDirection, float maxDegreesDelta, bool updateYawOnly = true);
    }

}