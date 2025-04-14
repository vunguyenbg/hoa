using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class Mask : MonoBehaviour
    {
        private Image img;
        private Color defaultColor;
        private Color hideColor;

        private void Awake()
        {
            img = GetComponent<Image>();
            if (img != null)
            {
                defaultColor = img.color;
                hideColor = new Color(img.color.r, img.color.g, img.color.b, 0);
            }
        }


        private void OnEnable()
        {
            Server.Get<OnOpacityMaskChanged>().AddListener(OnOpacityMaskChanged);
        }
        private void OnDisable()
        {
            Server.Get<OnOpacityMaskChanged>().RemoveListener(OnOpacityMaskChanged);
        }
        void OnOpacityMaskChanged(bool value)
        {
            if (img != null)
            {
                if (value)
                {
                    img.color = defaultColor;
                }
                else
                {
                    img.color = hideColor;
                }
            }
        }
    }
}
