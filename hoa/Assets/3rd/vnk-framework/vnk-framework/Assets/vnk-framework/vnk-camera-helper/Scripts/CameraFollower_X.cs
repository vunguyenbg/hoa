
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraFollower_X : MonoBehaviour
    {
        protected Tween tween;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float offetX = 1f;
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
            if (tween != null)
            {
                tween.Kill();
            }
            tween = transform.DOMoveX(position.x - offetX, duration); // transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        }
    }

}