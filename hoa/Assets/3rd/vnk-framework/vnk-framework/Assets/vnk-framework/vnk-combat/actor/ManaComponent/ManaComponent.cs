using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class ManaComponent : BaseComponent, IManaComponent, IListener
    {
        [Tooltip("In Stats, Value is Current Mana. BaseValue is Mana")]
        [SerializeField] private Stats stats = new Stats(0, new List<Modifier>());
        public Stats Stats { get => stats; set => stats = value; }

        public void OnAddListener(IActor actor)
        {
            actor.ActorAction.OnInitManaComplete += OnInitManaComplete;
        }

        public void OnRemoveListener(IActor actor)
        {
            actor.ActorAction.OnInitManaComplete -= OnInitManaComplete;
            stats.onStatsChanged -= OnStatsChanged;
        }

        void OnInitManaComplete(Stats _stats)
        {
            stats = _stats;
            stats.onStatsChanged += OnStatsChanged;
            CurrentMana = stats.Value;
            MaxMana = stats.BaseValue;
        }
        public float CurrentMana
        {
            set
            {
                stats.Value = value;
                if (stats.Value > stats.BaseValue)
                {
                    stats.Value = stats.BaseValue;
                }
            }
            get
            {
                return stats.Value;
            }
        }

        public float MaxMana
        {
            set
            {
                stats.BaseValue = Mathf.Floor(value);
            }
            get
            {
                return stats.BaseValue;
            }
        }

        public float Percent()
        {
            float value = (float)stats.Value / (float)stats.BaseValue;
            if (float.IsNaN(value))
            {
                return 0;
            }
            return value;
        }
        void OnStatsChanged()
        {
            actor.ActorAction.OnManaChanged?.Invoke(this);
        }
    }
}
