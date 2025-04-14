using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraObjectFollowerBottom : MonoBehaviour
    {
        private Camera camera;
        [SerializeField] private float positionZ;
        [SerializeField] private GameObject gameObject;
        public void Init(Camera _camera)
        {
            camera = _camera;
            OnExcute();
        }

        [Button]
        void OnExcute()
        {
            Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, 0, positionZ));
            gameObject.transform.position = stageDimensions;
        }

    }

}