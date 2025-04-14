using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFx : MonoBehaviour
{
    [SerializeField] private bool loop;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float startScaleValue = 1f;
    [SerializeField] private float endScaleValue = 1f;
    [SerializeField] private Ease ease = Ease.Linear;

    private void Start()
    {
        transform.localScale = new Vector3(startScaleValue, startScaleValue, startScaleValue);
        OmScale();
    }
    private void OnEnable()
    {
        transform.localScale = new Vector3(startScaleValue, startScaleValue, startScaleValue);
        OmScale();
    }
    void OmScale()
    {
        if (loop)
        {
            transform.DOScale(endScaleValue, duration).SetUpdate(true).OnComplete(()=> 
            {
                transform.DOScale(startScaleValue, duration).SetUpdate(true).OnComplete(() =>
                {
                    OmScale();
                });
            });
        }
        else
        {
            transform.DOScale(endScaleValue, duration).SetUpdate(true);
        }
    }

}
