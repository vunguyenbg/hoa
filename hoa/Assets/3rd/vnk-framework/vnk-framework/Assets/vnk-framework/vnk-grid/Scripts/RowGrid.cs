using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RowGrid : MonoBehaviour
    {
        public List<NodeGrid> nodes;

        public int y;

        public void Init(int _y)
        {
            y = _y;
        }
        public NodeGrid GetNode(int _x)
        {
            if (_x < nodes.Count)
            {
                return nodes[_x];
            }
            else
            {
                Debug.LogError("Node Base is Null, nodes length = " + nodes.Count + " x: " + _x + " y:" + y);
                return nodes[0];
            }

        }

    }

}