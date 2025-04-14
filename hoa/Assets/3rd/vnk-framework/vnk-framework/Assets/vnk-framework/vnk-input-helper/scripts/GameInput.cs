using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Yoolax.Framework
{
    public class GameInput : SingletonNormal<GameInput>
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
            onFingerUp?.Invoke(finger);
        }

    }
}