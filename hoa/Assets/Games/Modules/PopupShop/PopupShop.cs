

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yoolax.Framework;

public class PopupShop : BasePopup
{
    public static PopupShop Instance;

    public static void Show()
    {
        if (Instance == null)
        {
            GameObject temp = PopupManager.Instance.CreatePopup("PopupShop");
            Instance = temp.GetComponent<PopupShop>();
        }
        Instance.gameObject.SetActive(true);
        Instance.Init();
    }
    public static void Dismiss()
    {
        if (Instance != null)
        {
            Instance.Hide();
            Instance = null;
        }
    }

    public override void Init()
    {
        base.Init();
    }

    public void ButtonClose()
    {
        Dismiss();
    }
}