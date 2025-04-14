using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ItemUILoader : MonoBehaviour
    {
        private RenderTexture renderTexture;
        private string path;
        private string id;
        private RawImage rawImage;
        private bool isVisible;
        private Action<ItemUIBase, bool> onLoaded;
        private string itemPath;
        private void Awake()
        {
            isVisible = false;
        }

        public void Init(string _itemPath, string _path, string _id, RawImage _rawImage, bool force = false, Action<ItemUIBase, bool> _onLoaded = null)
        {
            itemPath = _itemPath;
            path = _path;
            id = _id;
            rawImage = _rawImage;
            onLoaded = _onLoaded;
            rawImage.enabled = false;
            rawImage.gameObject.SetActive(true);

            if (isVisible || force)
            {
                OnBecameVisible();
            }
        }
        public RenderTexture GetRenderTexture()
        {
            return renderTexture;
        }

        private void OnBecameVisible()
        {
            if (rawImage == null)
            {
                isVisible = true;
                return;
            }
            ModelUIManager.Instance.GetRenderTexture(itemPath, path, id, out ItemUIBase itemUIBase, out bool firstSpawn);
            if (itemUIBase != null)
            {
                if (ModelUIManager.Instance != null)
                {
                    renderTexture = itemUIBase.GetRenderTexture();
                    rawImage.texture = renderTexture;
                    rawImage.enabled = true;
                    onLoaded?.Invoke(itemUIBase, firstSpawn);
                }
            }
            else
            {
                rawImage.enabled = false;
            }
            isVisible = true;
        }
        private void OnBecameInvisible()
        {
            if (rawImage != null)
            {
                HideModel();
            }
            isVisible = false;
        }
        public void HideModel()
        {
            if (ModelUIManager.Instance != null)
            {
                ModelUIManager.Instance.HideModel(path, id);
            }
        }
    }
}
