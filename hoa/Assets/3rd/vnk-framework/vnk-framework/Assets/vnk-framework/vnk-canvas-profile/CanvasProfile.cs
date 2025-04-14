using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yoolax.Framework
{
    [Serializable]
    public class CanvasProfile
    {
        [ReadOnly]
        public string name;

        [ReadOnly]
        public Vector2 screenSize;

        public float aspectRatio;
    }
}