using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class ObjAwakePosition : MonoBehaviour
    {
        [HideInInspector] public Vector3 awakePosition;
        [HideInInspector] public Vector3 awakeLocalPosition;

        private void Awake()
        {
            awakePosition = transform.position;
            awakeLocalPosition = transform.localPosition;
        }
    }

}