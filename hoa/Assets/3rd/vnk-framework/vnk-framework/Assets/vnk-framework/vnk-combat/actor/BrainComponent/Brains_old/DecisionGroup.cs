using System.Collections;
using System.Collections.Generic;
using Yoolax.Framework;
using UnityEngine;

namespace Game.Test {
    public class DecisionGroup : Decision {
        [SerializeField] private DecisionOperator[] _decisionOperators;

        public override bool Decide(IActor context) {
            var result = false;

            foreach (var decisionOperator in _decisionOperators) {
                var decision = decisionOperator.Decision.Decide(context);
                decision = decisionOperator.IsNot ? !decision : decision;

                switch (decisionOperator.EDecisionOperator) {
                    case EDecisionOperator.None:
                        result = decision;
                        break;
                    case EDecisionOperator.And:
                        result = result && decision;
                        break;
                    case EDecisionOperator.Or:
                        result = result || decision;
                        break;
                }
            }

            return result;
        }
    }
}