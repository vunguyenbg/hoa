using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RotateFx : MonoBehaviour
    {
        [SerializeField] private float speed = 50f;
        private float z;

        private void Update()
        {
            z += speed * Time.deltaTime;
            if (z >= 360)
            {
                z = 0;
            }
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);

        }

    }
}