using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraFollower_Z : MonoBehaviour
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
            transform.position = new Vector3(transform.position.x, transform.position.y, position.z);
        }
    }

}