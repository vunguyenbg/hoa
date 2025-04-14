using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraActor : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        private CameraResulation cameraResulation;
        private CameraObjectFollowerBottom cameraObjectFollower;
        private void Awake()
        {
            cameraResulation = GetComponent<CameraResulation>();
            cameraObjectFollower = GetComponent<CameraObjectFollowerBottom>();
            cameraResulation.Init(camera);
            cameraObjectFollower.Init(camera);
        }
        //private void Start()
        //{
        //}


        //private void Update()
        //{
        //    cameraResulation.Init(camera);
        //    cameraObjectFollower.Init(camera);
        //}

        [Button]
        [HorizontalGroup("Resulation", 0.5f)]
        void AddCameraResulation()
        {
            if (cameraResulation == null)
            {
                cameraResulation = gameObject.AddComponent<CameraResulation>();
            }
        }
        [Button]
        [HorizontalGroup("Resulation", 0.5f)]
        void RemoveCameraResulation()
        {
            if (cameraResulation != null)
            {
                DestroyImmediate(cameraResulation);
            }
        }


        [Button]
        [HorizontalGroup("FollowerBottom", 0.5f)]
        void AddObjectFollowerBottom()
        {
            if (cameraObjectFollower == null)
            {
                cameraObjectFollower = gameObject.AddComponent<CameraObjectFollowerBottom>();
            }
        }
        [Button]
        [HorizontalGroup("FollowerBottom", 0.5f)]
        void RemoveObjectFollowerBottom()
        {
            if (cameraObjectFollower != null)
            {
                DestroyImmediate(cameraObjectFollower);
            }
        }
    }

}