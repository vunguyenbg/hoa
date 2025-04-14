using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class ItemUIBase : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private int countShow;
        [SerializeField] private bool isLoadData = true;
        private RenderTexture renderTexture;
        public GameObject objBase;
         protected GameObject objItem;

        public void LoadData(string path)
        {
            if (isLoadData)
            {
                GameObject obj = Resources.Load<GameObject>(path);
                if (obj != null)
                {
                    objItem = Instantiate(obj);
                    objItem.transform.SetParent(objBase.transform);
                    objItem.transform.localScale = Vector3.one;
                    objItem.transform.localPosition = Vector3.zero;
                }
                else
                {
                    Debug.LogError("Can't Load Item: " + path);
                }
            }
        }
        public RenderTexture GetRenderTexture()
        {
            return camera.targetTexture;
        }
        public RenderTexture SetRenderTexture(RenderTexture _renderTexture)
        {
            renderTexture = _renderTexture;
            return camera.targetTexture = _renderTexture;
        }
        public void ResetRenderTexture()
        {
            renderTexture = null;
        }
        public void AddCountShow()
        {
            countShow++;
        }
        public void RemoveCountShow()
        {
            countShow--;
            if (countShow <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

}