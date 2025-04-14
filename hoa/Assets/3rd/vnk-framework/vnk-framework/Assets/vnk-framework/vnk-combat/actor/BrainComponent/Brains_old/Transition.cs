using System.Collections;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;

namespace Game.Test {
    [System.Serializable]
    public class Transition {
        [SerializeField] private Decision _decision;
        [SerializeField, ClassExtends(typeof(State))] private ClassTypeReference _trueState;
        [SerializeField, ClassExtends(typeof(State))] private ClassTypeReference _falseState;

        public Decision Decision => _decision;
        public System.Type TrueState => _trueState == null ? null : _trueState;
        public System.Type FalseState => _falseState == null ? null : _falseState;
    }
}