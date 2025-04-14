using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class HealthBarText : MonoBehaviour, IListener
    {
        [SerializeField] private TextMeshProUGUI txtHealth;
        [SerializeField] private float duration = 0.3f;




        public void OnAddListener(IActor actor)
        {
            actor.ActorAction.OnHealthChanged += OnHealthChanged;
        }

        public void OnRemoveListener(IActor actor)
        {
            actor.ActorAction.OnHealthChanged -= OnHealthChanged;
        }

        public void OnHealthChanged(IHealthComponent healthComponent)
        {
            int hp = (int)healthComponent.CurrentHealth;
            DOTween.To(() => CurValue, x => CurValue = x, hp, 1f);
        }

        int curValue;
        int CurValue
        {
            set
            {
                curValue = value;
                txtHealth.text = curValue.ToString();
            }
            get
            {
                return curValue;

            }
        }
    }
}
