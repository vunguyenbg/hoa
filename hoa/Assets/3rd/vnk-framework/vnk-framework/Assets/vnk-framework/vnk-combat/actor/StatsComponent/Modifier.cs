
using System;
using UnityEngine;

namespace Yoolax.Framework
{
    [Serializable]
    public class Modifier
    {
        public float value;
        public float duration;
        public ModifierState modifierState;
        public Modifier(float _value, float _duration, ModifierState _modifierState)
        {
            value = _value;
            duration = _duration;
            modifierState = _modifierState;
        }
        public bool UpdateModifier(float time)
        {
            duration -= time;
            if (duration <= 0)
            {
                return true;
            }
            return false;
        }
    }

}