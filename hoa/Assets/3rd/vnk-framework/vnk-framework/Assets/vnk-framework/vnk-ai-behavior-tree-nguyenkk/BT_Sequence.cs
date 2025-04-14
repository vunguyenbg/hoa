using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class BT_Sequence : BT_Node
    {
        private List<BT_Node> lstNode;

        public BT_Sequence(List<BT_Node> _lstNode)
        {
            lstNode = _lstNode;
        }

        public override BT_Status Evaluate()
        {
            foreach (BT_Node node in lstNode)
            {
                switch (node.Evaluate())
                {
                    case BT_Status.Success:
                        continue;
                    case BT_Status.Failure:
                        status = BT_Status.Failure;
                        return status;
                    default:
                        status = BT_Status.Failure;
                        return status;
                }
            }
            status = BT_Status.Success;
            return status;
        }
    }

}