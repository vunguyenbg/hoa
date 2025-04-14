using System;
using UnityEngine;

namespace Yoolax.Framework
{
    public class TransformScaleProfile: BaseCanvasProfile<TransformScaleProfile.TransformProfile>
    {
        [Serializable]
        public class TransformProfile : CanvasProfile
        {
            public Vector3 localScale;
        }
        public new Transform m_transform;
        
        public override void OnApplyProfile(TransformProfile profile)
        {
            m_transform.localScale = profile.localScale;
        }
        
        #if UNITY_EDITOR
        private void Reset()
        {
            m_transform = GetComponent<Transform>();
        }
        #endif
    }
}