
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class ManaBarText : MonoBehaviour, IStart, IDestroy
    {
        [SerializeField] private TextMeshProUGUI txtMana;
        [SerializeField] private float duration = 0.3f;


        public void StartComponent(IActor actor)
        {
            actor.ActorAction.OnManaChanged += OnManaChanged;
        }

        public void DestroyComponent(IActor actor)
        {
            actor.ActorAction.OnManaChanged -= OnManaChanged;
        }

        public void OnManaChanged(IManaComponent manaComponent)
        {
            txtMana.text = manaComponent.CurrentMana.ToString();
        }
    }
}
