using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Yoolax.Framework
{
    public class SwapSprite : MonoBehaviour
    {

        [SerializeField] private GameObject objOn;
        [SerializeField] private GameObject objOff;

        public void ChangeSprite(bool isOn)
        {
            if (isOn)
            {
                objOff.SetActive(false);
                objOn.SetActive(true);
            }
            else
            {
                objOff.SetActive(true);
                objOn.SetActive(false);
            }
        }
    }

}