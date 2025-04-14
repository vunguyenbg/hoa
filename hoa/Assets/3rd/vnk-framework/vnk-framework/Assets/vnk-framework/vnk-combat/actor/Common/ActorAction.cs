using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class ActorAction
    {
        // //Brain
        // public Action<List<IState>> OnBrainAddState;
        // public Action OnBrainAddStateComplete;
        // public Action<IState> OnBrainChangeState;
        //Movement
        public Action<bool> OnGroundChanged;
        //State
        public Action<int, int> OnStateChanged;
        //Stats
        public Action<Stats> OnInitHPComplete;
        public Action<Stats> OnInitManaComplete;
        //HP
        public Action<IHealthComponent> OnHealthChanged;
        //Mana
        public Action<IManaComponent> OnManaChanged;
        //Animation
        public Action<AnimationInfo, EventInfo> OnAnimationEvent;
        public Action<AnimationInfo> OnAnimationComplete; 

        public Action<Vector3> OnMove;
        public Action<bool> OnFindTarget;
        public Action<Actor> OnSetTarget;
        public Action<IActor> OnDie;
        public Action OnTargetChanged;

    }
}
