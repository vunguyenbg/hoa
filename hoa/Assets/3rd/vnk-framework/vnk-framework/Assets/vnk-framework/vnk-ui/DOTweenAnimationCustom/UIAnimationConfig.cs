using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DOTweenAnimation))]
public class UIAnimationConfig : MonoBehaviour
{
    public DOTweenAnimation tweenAnimation;

    public bool isPlayBackwards = true;
    public float outro_TimeDelay;
}
