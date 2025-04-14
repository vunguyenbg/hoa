
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RotateConfigFx : MonoBehaviour
    {
        [SerializeField] private float speedX = 50f;
        [SerializeField] private float speedY = 50f;
        [SerializeField] private float speedZ = 50f;

        [SerializeField] private bool rotateX;
        [SerializeField] private bool rotateY;
        [SerializeField] private bool rotateZ;


        private float x;
        private float y;
        private float z;

        private void Update()
        {
            if (rotateX)
            {
                x += speedX * Time.deltaTime;
                if (x >= 360)
                {
                    x = 0;
                }
                transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
            if (rotateY)
            {
                y += speedY * Time.deltaTime;
                if (y >= 360)
                {
                    y = 0;
                }
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
            }

            if (rotateZ)
            {
                z += speedZ * Time.deltaTime;
                if (z >= 360)
                {
                    z = 0;
                }
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
            }

        }

    }
}