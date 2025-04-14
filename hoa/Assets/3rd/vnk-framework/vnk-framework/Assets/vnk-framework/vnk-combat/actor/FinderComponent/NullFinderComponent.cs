using UnityEngine;

namespace Yoolax.Framework
{
    public class NullFinderComponent : BaseComponent, IFinderComponent
    {
        public Actor Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Radius { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public LayerMask LayerMask { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool AutoFindTarget { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public void OnFindTarget(bool _force = false)
        {
            throw new System.NotImplementedException();
        }
    }
}