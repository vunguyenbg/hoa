using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Yoolax.Framework
{
    public class NodeGrid : MonoBehaviour
    {
        public int x;
        public int y;
        public bool locked;

        [SerializeField] protected NodeBase nodeBase;

        [SerializeField] protected TextMeshPro txtIndex;
        [SerializeField] protected TextMeshPro txtState;
        [SerializeField] protected SpriteRenderer spriteRenderer;
        protected bool isTest;
        //public int id;
        public void Init(int _x, int _y, bool _isTest = false)
        {
            //id = _id;
            isTest = _isTest;
            x = _x;
            y = _y;
            if (isTest)
            {
                txtIndex.gameObject.SetActive(true);
                txtIndex.text = x + ":" + y ;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g , spriteRenderer.color.b, 1);
            }
            else
            {
                txtIndex.gameObject.SetActive(false);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
            }
            txtState.gameObject.SetActive(false);
            transform.rotation = Camera.main.transform.rotation;
        }
        public void LockNode()
        {
            locked = true;
            if (isTest)
            {
                if (locked)
                {
                    txtState.gameObject.SetActive(true);
                    txtState.text = "locked";
                }
                else
                {
                    txtState.gameObject.SetActive(false);
                }
            }
        }
        public void SetSize(float size)
        {
            transform.localScale = new Vector3(size, size, size);
        }
        public NodeBase GetNodeBase()
        {
            return nodeBase;
        }
        public void SetNodeBase(NodeBase _nodeBase)
        {
            nodeBase = _nodeBase;
        }
        public void RemoveNodeBase()
        {
            nodeBase = null;
        }
        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }

}