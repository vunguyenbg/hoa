
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    [Serializable]
    public class Stats
    {
        [SerializeField]
        private float value;
        [SerializeField]
        private float baseValue;
        public List<Modifier> modifiers;
        [HideInInspector] public Action onStatsChanged;

        public float BaseValue
        {
            set
            {
                baseValue = value;
                onStatsChanged?.Invoke();
            }
            get
            {
                return (int)Mathf.Floor(baseValue);
            }
        }
        public float Value
        {
            get
            {
                return Mathf.Floor(value);
            }
            set
            {
                this.value = value;
                onStatsChanged?.Invoke();
            }
        }
        public int GetValueMultiply(float multiply = 1)
        {
            return (int)Mathf.Floor(value * multiply);
        }

        public Stats(float _value, List<Modifier> _modifiers)
        {
            BaseValue = _value;
            Value = _value;
            modifiers = _modifiers;
        }
        public void UpdateModifier(float deltaTime)
        {
            for (int i = modifiers.Count - 1; i >= 0 ; i--)
            {
                if (modifiers[i].UpdateModifier(deltaTime))
                {
                    modifiers.RemoveAt(i);
                    UpdateValueAfterAddModifier();
                }
            }
        }
        public void AddModifier(float _value, float _duration, ModifierState _modifierState)
        {
            switch (_modifierState)
            {
                case ModifierState.Multiply:
                    modifiers.Add(new Modifier((baseValue * _value) / 100, _duration, ModifierState.Multiply));
                    break;
                case ModifierState.Add:
                    modifiers.Add(new Modifier(_value, _duration, ModifierState.Add));
                    break;
                default:
                    Debug.LogError("Cant Add Modifier");
                    break;
            }
            UpdateValueAfterAddModifier();
        }
        public void AddModifier(Modifier modifier)
        {
            modifiers.Add(modifier);
            UpdateValueAfterAddModifier();
        }
        public void UpdateValueAfterAddModifier()
        {
            value = baseValue;
            for (int i = 0; i < modifiers.Count; i++)
            {
                value += modifiers[i].value;
            }
        }
    }
}
