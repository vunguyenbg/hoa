
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class NullStatsComponent : BaseComponent, IStatsComponent
    {
        public void Init(StatsType statsType, float value = 0)
        {
            throw new System.NotImplementedException();
        }

        public void SetStatsValue(StatsType statsType, float value = 0)
        {
            throw new System.NotImplementedException();
        }

        public Stats GetStatsValue(StatsType statsType)
        {
            throw new System.NotImplementedException();
        }

        public void AddModifier(StatsType statsType, float modifierValue, float duration, ModifierState modifierState)
        {
            throw new System.NotImplementedException();
        }

        public void AddModifier(StatsType statsType, Modifier modifier)
        {
            throw new System.NotImplementedException();
        }
    }
}
