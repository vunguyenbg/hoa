using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class ManaBarImage : MonoBehaviour, IAwake, IDestroy
    {
        [SerializeField] private Image imgManaBar;
        [SerializeField] private float duration = 0.5f;
        public void AwakeComponent(IActor actor)
        {
            actor.ActorAction.OnManaChanged += OnManaChanged;
        }

        public void DestroyComponent(IActor actor)
        {
            actor.ActorAction.OnManaChanged -= OnManaChanged;
        }

        public void OnManaChanged(IManaComponent manaComponent)
        {
            imgManaBar.DOFillAmount(manaComponent.Percent(), duration);
        }
    }
}
