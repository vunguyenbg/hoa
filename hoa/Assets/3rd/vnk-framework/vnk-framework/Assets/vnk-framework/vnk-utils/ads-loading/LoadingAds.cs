using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class LoadingAds : MonoBehaviour
    {
        [SerializeField] private GameObject objVideo;
        [SerializeField] private GameObject objLoading;
        bool isLoading;
        private void OnEnable()
        {
            Server.Get<OnVideoLoaded>().AddListener(CheckShowVideo);
        }
        private void OnDisable()
        {
            Server.Get<OnVideoLoaded>().RemoveListener(CheckShowVideo);
        }
        void CheckShowVideo(bool result)
        {
            if (result)
            {
                objVideo.SetActive(true);
                objLoading.SetActive(false);
            }
            else
            {
                objVideo.SetActive(false);
                objLoading.SetActive(true);
            }
        }
    }

}