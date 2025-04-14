using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Test {
    public class Brain : ScriptableObject {
        [SerializeField] private Transition[] _coreTransitions;
        [SerializeField] private TransitionByState[] _localTransitions;

        public Transition[] CoreTransitions => _coreTransitions;
        public TransitionByState[] Localtransitions => _localTransitions;
    }
}