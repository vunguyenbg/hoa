using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class SwapGroupEffect : MonoBehaviour
    {
        [SerializeField] private GameObject obj_1;
        [SerializeField] private GameObject obj_2;
        [SerializeField] private float duration = 0.25f;

        private Vector3 positionObj_1;
        private Vector3 positionObj_2;
        private void Awake()
        {
            positionObj_1 = obj_1.transform.position;
            positionObj_2 = obj_2.transform.position;
        }

        public void Swap(bool isOn, Action onComplete)
        {
            if (isOn)
            {
                obj_2.transform.DOMove(positionObj_1, duration).OnComplete(() =>
                {
                    obj_2.transform.position = positionObj_2;
                    onComplete?.Invoke();
                });
            }
            else
            {
                obj_1.transform.DOMove(positionObj_2, duration).OnComplete(() =>
                {
                    obj_1.transform.position = positionObj_1;
                    onComplete?.Invoke();
                });
            }
        }
    }
}
