using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public abstract class BT_Node
    {
        public BT_Status status;
        public abstract BT_Status Evaluate();
    }

}