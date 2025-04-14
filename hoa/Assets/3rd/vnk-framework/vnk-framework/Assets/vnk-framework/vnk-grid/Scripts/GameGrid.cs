using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class GameGrid : MonoBehaviour
    {
        [SerializeField] private GridInitType gridInitType;
        [SerializeField] private bool upGrid;
        [SerializeField] private int row;
        [SerializeField] private int column;
        [SerializeField] private float paddingX = 1;
        [SerializeField] private float paddingY = 1;
        [SerializeField] private float sizeNodeBase = 1;
        [SerializeField] private float offsetGridX = 0;
        [SerializeField] private float offsetGridY = 0;
        [SerializeField] private bool isTest;
        [SerializeField] private List<RowGrid> rows = new List<RowGrid>();
        [SerializeField] private RowGrid rowPrefabs;
        [SerializeField] private NodeGrid nodeBasePrefabs;


        private void Awake()
        {
            if (gridInitType == GridInitType.Awake)
            {
                Init();
            }
        }
        private void Start()
        {
            if (gridInitType == GridInitType.Start)
            {
                Init();
            }
        }

        //Init
        public void InitNormal(int _row, int _column)
        {
            if (gridInitType == GridInitType.None)
            {
                row = _row;
                column = _column;
                Init(false);
            }
            else
            {
                Debug.LogError("Grid only init when GridInitType == none");
            }
        }
        
        void Init(bool isEditor = false)
        {
            if (isEditor)
            {
                ClearOldNodeEditor();
            }
            else
            {
                ClearOldNode();
            }
            rows.Clear();
            //Init Row
            RowGrid _row = null;
            NodeGrid _nodeBase = null;
            float offsetX = 0;
            float offsetY = 0;
            if (row % 2 == 0)
            {
                offsetY = paddingY / 2;
            }
            if (column % 2 == 0)
            {
                offsetX = paddingX / 2;
            }

            float deltaX = (column / 2);
            float deltaY = (row / 2);
            int upAnDownGrid = upGrid ? 1 : -1;


            for (int y = 0; y < row; y++)
            {
                _row = Instantiate(rowPrefabs, transform);
                _row.gameObject.name = "Row_" + y;
                _row.transform.localPosition = new Vector3(0, upAnDownGrid * (y * paddingY) - ((deltaY * paddingY) - offsetY) + offsetGridY); // Up down
                _row.Init(y);
                rows.Add(_row);

                //Init Node Base
                _row.nodes = new List<NodeGrid>();
                for (int x = 0; x < column; x++)
                {
                    _nodeBase = Instantiate(nodeBasePrefabs, _row.transform);
                    _nodeBase.gameObject.name = "Node_" + x;
                    _nodeBase.transform.localPosition = new Vector3((x * paddingX) - ((deltaX * paddingX) - offsetX) + offsetGridX, 0);
                    _nodeBase.Init(x, y, isTest);
                    _nodeBase.SetSize(sizeNodeBase);
                    _row.nodes.Add(_nodeBase);
                }
            }
        }
        void ClearOldNode()
        {
            Transform tf = null;
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                tf = transform.GetChild(i);
                if (tf != null)
                {
                    Destroy(tf.gameObject);
                }
            }
            rows.Clear();

        }
        void ClearOldNodeEditor()
        {
            Transform tf = null;
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                tf = transform.GetChild(0);
                if (tf != null)
                {
                    DestroyImmediate(tf.gameObject);
                }
            }
            rows.Clear();
        }
        [Button]
        void CreateGrid()
        {
            Init(true);
        }
        [Button]
        void RemoveGrid()
        {
            ClearOldNodeEditor();
        }


        //Set Properties
        private RowGrid GetRow(int _y)
        {
            if (_y < rows.Count)
            {
                return rows[_y];
            }
            else
            {
                Debug.LogError("Null: rows length = " + rows.Count + "y: " + _y);
                return rows[0];
            }
        }
        public void BlockNode(int _x, int _y)
        {
            if (_x < rows.Count)
            {
                GetRow(_y).GetNode(_x).LockNode();
            }
            else
            {
                Debug.LogError("Null: rows length = " + rows.Count);
            }
        }
        public void SetNodeToMatrix(int _x, int _y, NodeBase _nodeBase)
        {
            GetRow(_y).GetNode(_x).SetNodeBase(_nodeBase);
        }
        public void RemoveNodeFromMatrix(int _x, int _y)
        {
            GetRow(_y).GetNode(_x).RemoveNodeBase();
        }
        public NodeGrid GetNodeFromMatrix(int _x, int _y)
        {
            return GetRow(_y).GetNode(_x);  
        }
        public NodeBase GetNodeBaseFromMatrix(int _x, int _y)
        {
            return GetRow(_y).GetNode(_x).GetNodeBase();
        }
        public bool IsBlock(int _x, int _y)
        {
            return GetRow(_y).GetNode(_x).locked;
        }
        public Vector3 GetPositionUp(int _x, int _y)
        {
            Vector3 pos = GetRow(_y).GetNode(_x).GetPosition();
            return new Vector3(pos.x, pos.y + paddingY, pos.z);
        }
    }
}
