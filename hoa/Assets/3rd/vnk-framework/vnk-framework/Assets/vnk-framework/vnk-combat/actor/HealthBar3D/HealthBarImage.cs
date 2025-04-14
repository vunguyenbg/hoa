using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class HealthBarImage : MonoBehaviour, IListener
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private float duration = 0.3f;


        public void OnAddListener(IActor actor)
        {
            actor.ActorAction.OnHealthChanged += OnHealthChanged;
        }

        public void OnRemoveListener(IActor actor)
        {
            actor.ActorAction.OnHealthChanged -= OnHealthChanged;
        }
        void OnHealthChanged(IHealthComponent healthComponent)
        {
            healthBar.DOFillAmount(healthComponent.Percent(), duration);
        }
    }
}
