using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class CameraFollower : MonoBehaviour
    {
        private void OnEnable()
        {
            CameraHelper.OnFollow += OnFollow;
        }
        private void OnDisable()
        {
            CameraHelper.OnFollow -= OnFollow;
        }
        private void OnFollow(Vector3 position)
        {
            transform.position = position;
        }
    }

}