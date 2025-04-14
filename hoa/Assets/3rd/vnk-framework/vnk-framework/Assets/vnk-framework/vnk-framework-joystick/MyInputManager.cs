using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class MyInputManager : MonoBehaviour
    {
        public static Action btnCall;

        private void LateUpdate()
        {
            if (btnCall != null)
                btnCall();
        }
    }

}