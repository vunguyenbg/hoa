
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{

    [RequireComponent(typeof(Camera))]
    public class CameraPropertyOverrider : MonoBehaviour
    {
        public bool isSafeAreaCamera = true;
        public bool useFullSize = true;

        private Camera myCamera;
        private Rect RectSize
        {
            get
            {
                if (myCamera == null)
                {
                    myCamera = GetComponent<Camera>();
                }
                return myCamera.rect;
            }
        }

        private Rect SafeSize
        {
            get
            {
                float safeX = Screen.safeArea.x / Screen.width;
                float safeY = Screen.safeArea.y / Screen.height;
                float safeW = Screen.safeArea.width / Screen.width;
                float safeH = Screen.safeArea.height / Screen.height;

                Rect originalRect = useFullSize ? new Rect(0, 0, 1, 1) : RectSize;

                return new Rect(safeX + originalRect.x / safeW,
                                safeY + originalRect.y / safeH,
                                safeW / originalRect.width,
                                safeH / originalRect.height);
            }
        }

        // Update Method
        public void UpdateCameraProperty(Rect offset)
        {
            if (isSafeAreaCamera)
            {
                if (myCamera == null)
                {
                    myCamera = GetComponent<Camera>();
                }
                Rect rect = new Rect(SafeSize.x + offset.x, SafeSize.y + offset.y, SafeSize.width + offset.width, SafeSize.height + offset.height);
                myCamera.rect = rect;
            }
            else
            {
                myCamera.rect = useFullSize ?
                     new Rect(0 + offset.x, 0 + offset.y, 1 + offset.width, 1 + offset.height)
                    : new Rect(SafeSize.x + offset.x, SafeSize.y + offset.y, SafeSize.width + offset.width, SafeSize.height + offset.height);
            }
        }
    }
}