using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class Scroll : ScrollRect
    {
        List<LeanFinger> leanFingers = new List<LeanFinger>();
        private LeanFinger curFinger;
        public Vector2 MultiTouchPosition
        {
            get
            {
                Vector2 position = Vector2.zero;
#if UNITY_EDITOR
                position += new Vector2(Input.mousePosition.x, Input.mousePosition.y);
#else
                for (int i = 0; i < Input.touchCount; i++)
                {
                    position += Input.touches[i].position;
                }
                position /= Input.touchCount;
#endif
                return position;
            }
        }


        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (curFinger == null)
                return;
            eventData.position = MultiTouchPosition;
            base.OnBeginDrag(eventData);
        }
        public override void OnDrag(PointerEventData eventData)
        {
            if (curFinger == null)
                return;
            eventData.position = MultiTouchPosition;
            base.OnDrag(eventData);
        }
        public override void OnEndDrag(PointerEventData eventData)
        {
            if (curFinger == null)
                return;
            eventData.position = MultiTouchPosition;
            base.OnEndDrag(eventData);
        }



        protected override void OnEnable()
        {
            LeanTouch.OnFingerDown += OnFingerDown;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        protected override void OnDisable()
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }

        private void OnFingerDown(LeanFinger finger)
        {
            if (!finger.IsOverGui)
                return;
            if (!leanFingers.Contains(finger))
            {
                leanFingers.Add(finger);
            }
            curFinger = GetMinFinger();
        }
        private void OnFingerUp(LeanFinger finger)
        {
            leanFingers.Remove(finger);
            curFinger = GetMinFinger();
        }

        LeanFinger GetMinFinger()
        {
            LeanFinger leanFinger = null;
            int index = 10000;
            for (int i = 0; i < leanFingers.Count; i++)
            {
                leanFinger = leanFingers[i];
                if (leanFinger.Index <= index)
                {
                    index = leanFinger.Index;
                }
            }
            return leanFinger;
        }
    }

}