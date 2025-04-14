using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapButton : MonoBehaviour
{
    public Action<bool> onSwap;
    [SerializeField] RectTransform tfButton;
    [SerializeField] RectTransform tfOn;
    [SerializeField] RectTransform tfOff;
    [SerializeField] private float duration = 0.25f;
    private bool isOn;

    public void Init(bool isOn)
    {
        this.isOn = isOn;
        if (isOn)
        {
            //tfButton.anchoredPosition = tfOn.anchoredPosition;
            tfOn.gameObject.SetActive(true);
            tfOff.gameObject.SetActive(false);
        }
        else
        {
            //tfButton.anchoredPosition = tfOff.anchoredPosition;
            tfOn.gameObject.SetActive(false);
            tfOff.gameObject.SetActive(true);
        }
    }
   public void ButtonOn()
    {
        if (isOn)
        {
            //tfButton.DOAnchorPos(tfOff.anchoredPosition, duration).OnComplete(() =>
            //{
            //    isOn = false;
            //});
            onSwap?.Invoke(false);

            tfOn.gameObject.SetActive(false);
            tfOff.gameObject.SetActive(true);
            isOn = false;
        }
        //if (!isOn)
        //{
        //    //tfButton.DOAnchorPos(tfOn.anchoredPosition, duration).OnComplete(() =>
        //    //{
        //    //    isOn = true;
        //    //});
        //    onSwap?.Invoke(true);
        //    tfOn.gameObject.SetActive(true);
        //    tfOff.gameObject.SetActive(false);
        //}
    }
    public void ButtonOff()
    {
        //if (isOn)
        //{
        //    //tfButton.DOAnchorPos(tfOff.anchoredPosition, duration).OnComplete(() =>
        //    //{
        //    //    isOn = false;
        //    //});
        //    onSwap?.Invoke(false);

        //    tfOn.gameObject.SetActive(false);
        //    tfOff.gameObject.SetActive(true);
        //}

        if (!isOn)
        {
            //tfButton.DOAnchorPos(tfOn.anchoredPosition, duration).OnComplete(() =>
            //{
            //    isOn = true;
            //});
            onSwap?.Invoke(true);
            tfOn.gameObject.SetActive(true);
            tfOff.gameObject.SetActive(false);
            isOn = true;
        }
    } 
}
