using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class GameInputUI : MonoBehaviour
    {
        private LeanFinger curFinger;
        public Action<LeanFinger> onFingerDown;
        public Action<LeanFinger> onFingerUpdate;
        public Action<LeanFinger> onFingerUp;


        private void OnEnable()
        {
            LeanTouch.OnFingerDown += OnFingerDown;
            LeanTouch.OnFingerUpdate += OnFingerUpdate;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
            LeanTouch.OnFingerUpdate -= OnFingerUpdate;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }

        private void OnFingerDown(LeanFinger finger)
        {
            if (curFinger == null)
            {
                curFinger = finger;
            }
            if (finger.IsOverGui)
            {
                return;
            }
            onFingerDown?.Invoke(curFinger);
        }
        private void OnFingerUpdate(LeanFinger finger)
        {
            if (curFinger != finger)
            {
                return;
            }
            if (finger.IsOverGui)
            {
                return;
            }
            onFingerUpdate?.Invoke(curFinger);
        }
        private void OnFingerUp(LeanFinger finger)
        {
            if (curFinger == finger)
            {
                curFinger = null;
            }
            else
            {
                return;
            }
            if (finger.IsOverGui)
            {
                return;
            }
            onFingerUp?.Invoke(finger);
        }
    }
}
