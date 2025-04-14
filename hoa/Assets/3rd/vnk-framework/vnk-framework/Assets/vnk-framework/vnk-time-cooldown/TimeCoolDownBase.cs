

namespace Yoolax.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class TimeCoolDownBase : MonoBehaviour
    {
        [SerializeField] protected int curTime;
        protected IEnumerator check;
        protected Action onComplete;

        public virtual void Run(int _curTime, Action _onComplete = null)
        {
            onComplete = _onComplete;
            this.curTime = _curTime;

            if (curTime >= 0)
            {
                UpdateUI_Time(curTime);
                if (check != null)
                {
                    StopCoroutine(check);
                }
                check = DelayCoolDownTime();
                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(check);
                }
                StartTime();
            }
            else
            {
                StopTime();
                onComplete?.Invoke();
            }
        }
        protected IEnumerator DelayCoolDownTime()
        {
            yield return Helper.Wait(1f);
            curTime--;
            UpdateUI_Time(curTime);
            if (curTime <= 0)
            {
                StopTime();
                onComplete?.Invoke();
            }
            else
            {
                check = DelayCoolDownTime();
                if (gameObject.activeInHierarchy)
                    StartCoroutine(check);
            }
        }
        protected virtual void OnDisable()
        {
            if (check != null)
            {
                if (gameObject.activeInHierarchy)
                    StopCoroutine(check);
            }
        }
        public int GetCurrentTime()
        {
            return curTime;
        }

        protected virtual void StartTime()
        {

        }
        protected virtual void StopTime()
        {
        }

        protected virtual void UpdateUI_Time(int time)
        {

        }
    }

}