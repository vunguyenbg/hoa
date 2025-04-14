
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yoolax.Framework;

public class PopupMainMenu : BasePopup
{
    public static PopupMainMenu Instance;

    public static void Show()
    {
        if (Instance == null)
        {
            GameObject temp = PopupManager.Instance.CreatePopup("PopupMainMenu");
            Instance = temp.GetComponent<PopupMainMenu>();
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

    public void ButtonPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ButtonSetting()
    {
        PopupSetting.Show(true, () =>
        {
            
        });
    }
}