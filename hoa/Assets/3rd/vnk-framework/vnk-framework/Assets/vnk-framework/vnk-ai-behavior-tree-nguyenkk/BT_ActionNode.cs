using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class BT_ActionNode : BT_Node
    {
        public delegate BT_Status ActionNodeDelegate();
        private ActionNodeDelegate actNode;

        public BT_ActionNode(ActionNodeDelegate _actNode)
        {
            actNode = _actNode;
        }

        public override BT_Status Evaluate()
        {
            switch (actNode())
            {
                case BT_Status.Success:
                    status = BT_Status.Success;
                    return status;
                case BT_Status.Failure:
                    status = BT_Status.Failure;
                    return status;
                default:
                    status = BT_Status.Failure;
                    return status;
            }
        }
    }
}
