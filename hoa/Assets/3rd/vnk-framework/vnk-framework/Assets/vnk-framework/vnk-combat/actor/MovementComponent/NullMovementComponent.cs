

using DG.Tweening;
using UnityEngine;

namespace Yoolax.Framework
{
    public class NullMovementComponent : BaseComponent, IMovementComponent
    {
        public float Speed { get; set; }
        public bool IsLocked { get; set; }
        public bool Freeze { get; set; }

        public void Move(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void RotateTowards(Vector3 worldDirection, float maxDegreesDelta, bool updateYawOnly = true)
        {
            throw new System.NotImplementedException();
        }
    }
}