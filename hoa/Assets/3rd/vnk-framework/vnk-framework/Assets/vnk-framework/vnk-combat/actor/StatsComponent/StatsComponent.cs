using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class StatsComponent : BaseComponent, IStatsComponent, IUpdate
    {
        [ShowInInspector]
        private Dictionary<StatsType, Stats> stats = new Dictionary<StatsType, Stats>();


        public void Init(StatsType statsType, float baseValue = 0)
        {
            if (stats.ContainsKey(statsType))
            {
                stats[statsType].BaseValue = baseValue;
                stats[statsType].Value = baseValue;
            }
            else
            {
                stats.Add(statsType, new Stats(baseValue, new List<Modifier>()));
            }
            if (statsType == StatsType.HP)
            {
                actor.ActorAction.OnInitHPComplete?.Invoke(stats[statsType]);
            }
            else if (statsType == StatsType.MANA)
            {
                actor.ActorAction.OnInitManaComplete?.Invoke(stats[statsType]);
            }
        }

        public void AddModifier(StatsType statsType, float modifierValue, float duration, ModifierState modifierState)
        {
            if (stats.ContainsKey(statsType))
            {
                stats[statsType].AddModifier(modifierValue, duration, modifierState);
            }
            else
            {
                stats.Add(statsType, new Stats(0, new List<Modifier>()));
                stats[statsType].AddModifier(modifierValue, duration, modifierState);
            }
        }
        public void AddModifier(StatsType statsType, Modifier modifier)
        {
            if (stats.ContainsKey(statsType))
            {
                stats[statsType].AddModifier(modifier);
            }
            else
            {
                stats.Add(statsType, new Stats(0, new List<Modifier>()));
                stats[statsType].AddModifier(modifier);
            }
        }

        public void UpdateComponent()
        {
            foreach (var stats in stats)
            {
                stats.Value.UpdateModifier(Time.deltaTime);
            }
        }

        public void SetStatsValue(StatsType statsType, float value = 0)
        {
            if (stats.ContainsKey(statsType))
            {
                stats[statsType].Value = value;
            }
            else
            {
                stats.Add(statsType, new Stats(value, new List<Modifier>()));
            }
        }

        public Stats GetStatsValue(StatsType statsType)
        {
            stats.TryGetValue(statsType, out Stats statsValue);
            if (statsValue != null)
            {
                return statsValue;
            }
            else
            {
                Debug.LogError("Cant Find Stats: " + name);
                return new Stats(1, new List<Modifier>());
            }
        }
    }
}
