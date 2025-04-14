using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class BT_Selector : BT_Node
    {
        private List<BT_Node> lstNode;
        public BT_Selector(List<BT_Node> _lstNode)
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
                        status = BT_Status.Success;
                        return status;
                    case BT_Status.Failure:
                        continue;
                    default:
                        continue;
                }
            }
            status = BT_Status.Failure;
            return status;
        }
    }

}
