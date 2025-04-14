
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class HealthComponent : BaseComponent, IHealthComponent, IListener
    {
        [Tooltip("In Stats, Value is Current HP. BaseValue is MaxHP")]
        [SerializeField] private Stats stats = new Stats(0, new List<Modifier>());
        public Stats Stats { get => stats; set => stats = value; }
        [SerializeField] private bool immortal;


        public void OnAddListener(IActor actor)
        {
            actor.ActorAction.OnInitHPComplete += OnInitHPComplete;
        }

        public void OnRemoveListener(IActor actor)
        {
            actor.ActorAction.OnInitHPComplete -= OnInitHPComplete;
            stats.onStatsChanged -= OnStatsChanged;
        }

        void OnInitHPComplete(Stats _stats)
        {
            stats = _stats;
            stats.onStatsChanged += OnStatsChanged;
            MaxHealth = stats.BaseValue;
            CurrentHealth = stats.Value;
        }


        public float CurrentHealth
        {
            set
            {
                if (immortal)
                    return;
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

        public float MaxHealth
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

        public bool Immortal { get => immortal; set => immortal = value; }

        public float Percent()
        {
            return stats.Value / stats.BaseValue;
        }
        void OnStatsChanged()
        {
            actor.ActorAction.OnHealthChanged?.Invoke(this);
        }
    }
}
