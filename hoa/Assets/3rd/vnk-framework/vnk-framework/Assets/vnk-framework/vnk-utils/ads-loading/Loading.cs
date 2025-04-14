using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class Loading : MonoBehaviour
    {
        public float speed = 10;
        private void Update()
        {
            transform.Rotate(Vector3.back * speed);
        }
    }

}