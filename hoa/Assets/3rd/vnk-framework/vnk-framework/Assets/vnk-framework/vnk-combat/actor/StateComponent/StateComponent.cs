using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yoolax.Framework {
    public class StateComponent : BaseComponent, IStateComponent{
        
        [SerializeField] protected bool locked;
        public bool IsLocked => locked;

        [SerializeField] protected int currentState;
        [SerializeField] protected int oldState;
        
        public void Lock(bool isLocked)
        {
            locked = isLocked;
        }
        public bool IsState(int state)
        {
            return currentState == state;
        }
        public void ChangeState(int state)
        {
            if (locked)
                return;
            if (currentState != state)
            {
                oldState = currentState;
                currentState = state;
                actor.ActorAction.OnStateChanged?.Invoke(currentState, oldState);
            }
        }
    }
}