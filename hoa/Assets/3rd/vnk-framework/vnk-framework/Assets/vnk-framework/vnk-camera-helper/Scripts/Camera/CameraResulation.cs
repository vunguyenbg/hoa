using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraResulation : MonoBehaviour
    {
        private Camera camera;
        [SerializeField] private float fieldOfView;
        [SerializeField] private float minFieldOfView;
        private bool isGetFieldOfView;

        private void Awake()
        {
            isGetFieldOfView = false;
        }
        public void Init(Camera _camera)
        {
            camera = _camera;
            if (!isGetFieldOfView)
            {
                isGetFieldOfView = true;
                fieldOfView = camera.fieldOfView;
            }
            UpdateCameraField();
        }

        void UpdateCameraField()
        {
            float value = fieldOfView * ((float)(1080 * Screen.height) / (float)(1920 * Screen.width));
            if (value < minFieldOfView)
            {
                value = minFieldOfView;
            }
            camera.fieldOfView = value;
        }
    }

}