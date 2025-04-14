
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RotateEffect : MonoBehaviour
    {
        [SerializeField] private float xSpeed = 50f;
        [SerializeField] private float ySpeed = 50f;
        [SerializeField] private float zSpeed = 50f;
        [SerializeField] private bool x;
        [SerializeField] private bool y;
        [SerializeField] private bool z;
        private float xValue;
        private float yValue;
        private float zValue;

        private void Update()
        {
            if (x)
            {
                xValue += xSpeed * Time.deltaTime;
                if (xValue >= 360)
                {
                    xValue = 0;
                }
                transform.localEulerAngles = new Vector3(xValue, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
            if (y)
            {
                yValue += ySpeed * Time.deltaTime;
                if (yValue >= 360)
                {
                    yValue = 0;
                }
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yValue, transform.localEulerAngles.z);
            }

            if (z)
            {
                zValue += zSpeed * Time.deltaTime;
                if (zValue >= 360)
                {
                    zValue = 0;
                }
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, zValue);
            }

        }

    }
}