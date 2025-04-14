using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public interface IStatsComponent
    {
        void Init(StatsType statsType, float value = 0);
        void SetStatsValue(StatsType statsType, float value = 0);
        Stats GetStatsValue(StatsType statsType);
        void AddModifier(StatsType statsType, float modifierValue, float duration, ModifierState modifierState);
        void AddModifier(StatsType statsType, Modifier modifier);

    }
}
