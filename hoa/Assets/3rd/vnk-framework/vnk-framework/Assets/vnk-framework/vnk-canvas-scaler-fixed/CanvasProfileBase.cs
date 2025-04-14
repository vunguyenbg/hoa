using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

namespace Yoolax.Framework
{
    [SerializeField]
    public class CanvasProfileBase
    {
        // public string name;
#pragma warning disable 162
        public Vector2 screenSize;
#pragma warning restore 162

#pragma warning disable 162
        public float aspectRatio;
#pragma warning restore 162

        public ScreenMatchMode screenMatchMode;

        public float match = 0;

        public CanvasProfileBase(Vector2 _screenSize, float _aspectRatio, ScreenMatchMode _screenMatchMode, float _match)
        {
           // name = _name;
            screenSize = _screenSize;
            aspectRatio = _aspectRatio;
            screenMatchMode = _screenMatchMode;
            match = _match;
        }
    }

}