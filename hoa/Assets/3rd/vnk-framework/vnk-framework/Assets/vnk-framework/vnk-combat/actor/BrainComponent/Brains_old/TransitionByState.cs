using System.Collections;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;

namespace Game.Test {
    [System.Serializable]
    public class TransitionByState {
        [SerializeField, ClassExtends(typeof(State))] private ClassTypeReference _state;
        [SerializeField] private Transition[] _transitions;

        public System.Type StateType { get { return _state.Type; } }
        public Transition[] Transitions { get { return _transitions; } }
    }
}