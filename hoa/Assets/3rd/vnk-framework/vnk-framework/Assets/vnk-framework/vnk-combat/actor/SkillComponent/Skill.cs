using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class Skill : ISkill
    {
        [SerializeField] private bool isBusy;
        [SerializeField] private float currentTimeCoolDown;
        [SerializeField] private float maxTimeCoolDown;
        private Action<float> onCoolDown;
        private Action onCoolDownComplete;
        public bool IsBusy => isBusy;
        public float CurrentTimeCoolDown { get => currentTimeCoolDown; set => currentTimeCoolDown = value; }
        public float MaxTimeCoolDown { get => maxTimeCoolDown; set => maxTimeCoolDown = value; }
        public Action<float> OnCoolDown { get => onCoolDown; set => onCoolDown = value; }
        public Action OnCoolDownComplete { get => onCoolDownComplete; set => onCoolDownComplete = value; }

        public Skill(float _currentTimeCoolDown, float _maxTimeCoolDown)
        {
            currentTimeCoolDown = _currentTimeCoolDown;
            maxTimeCoolDown = _maxTimeCoolDown;
            isBusy = true;
        }

        public void CastSkill()
        {
            isBusy = true;
            currentTimeCoolDown = maxTimeCoolDown;
        }

        public void UpdateTimeCoolDown(float deltaTime)
        {
            if (isBusy)
            {
                currentTimeCoolDown -= deltaTime;
                if (currentTimeCoolDown <= 0)
                {
                    isBusy = false;
                    onCoolDownComplete?.Invoke();
                }
                onCoolDown?.Invoke(currentTimeCoolDown);
            }
        }
    }

}