using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Test {
    [System.Serializable]
    public class DecisionOperator {
        [SerializeField] private Decision _decision;
        [SerializeField] private EDecisionOperator _operator;
        [SerializeField] private bool _not;

        public DecisionOperator(Decision decision, EDecisionOperator @operator, bool not) {
            _decision = decision;
            _operator = @operator;
            _not = not;
        }

        public Decision Decision => _decision;
        public EDecisionOperator EDecisionOperator => _operator;
        public bool IsNot => _not;
    }
}