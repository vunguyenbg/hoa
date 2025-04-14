using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasResolution : MonoBehaviour
    {
        protected CanvasScaler canvasScaler;

        [TableList, ShowInInspector] protected List<CanvasProfileBase> profiles = new List<CanvasProfileBase>();
        protected virtual void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }
        protected virtual void Start()
        {

        }

    }

}
