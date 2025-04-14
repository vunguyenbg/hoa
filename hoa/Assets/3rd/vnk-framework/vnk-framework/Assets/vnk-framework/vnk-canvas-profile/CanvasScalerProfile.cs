using System;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class CanvasScalerProfile : BaseCanvasProfile<CanvasScalerProfile.AspectProfile> {
        [Serializable]
        public class AspectProfile : CanvasProfile {
            public CanvasScaler.ScreenMatchMode screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            public float match = 0;
        }

        public CanvasScaler canvasScaler;

        public override void OnApplyProfile(AspectProfile profile) {
            canvasScaler = GetComponent<CanvasScaler>();
            canvasScaler.screenMatchMode = profile.screenMatchMode;
            canvasScaler.matchWidthOrHeight = profile.match;
        }

#if UNITY_EDITOR
        private void Reset() {
            canvasScaler = GetComponent<CanvasScaler>();
        }
#endif
    }
}