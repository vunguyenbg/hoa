using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class ToggleCustom : MonoBehaviour
    {
        [SerializeField] private GameObject objTick;
        public Action onChanged;
        private bool isOn;

        public void Init(bool _isOn)
        {
            isOn = _isOn;
            UpdateUI();
        }

        public bool IsOn 
        {
            set
            {
                isOn = value;
                UpdateUI();
                onChanged?.Invoke();
            }
            get
            {
                return isOn; 
            }
        }

        public void OnClick()
        {
            IsOn = !isOn;
            UpdateUI();
        }
        void UpdateUI()
        {
            if (isOn)
            {
                objTick.SetActive(true);
            }
            else
            {
                objTick.SetActive(false);
            }
        }

    }

}