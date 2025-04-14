
using Yoolax.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Xml.Linq;

public class PopupSetting : BasePopup
{
    public static PopupSetting Instance;
    [SerializeField] private SwapButton swapButton_Music;
    [SerializeField] private SwapButton swapButton_Sound;
    private Action onClose;
    [SerializeField] private GameObject objButtonHome;
    private bool isMainMenu;


    public static void Show(bool isMainMenu, Action onClose)
    {
        if (Instance == null)
        {
            GameObject temp = PopupManager.Instance.CreatePopup("PopupSetting");
            Instance = temp.GetComponent<PopupSetting>();
        }
        Instance.isMainMenu = isMainMenu;
        Instance.onClose = onClose;
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
        swapButton_Music.onSwap += OnSwapButton_Music;
        swapButton_Sound.onSwap += OnSwapButton_Sound;

        swapButton_Music.Init(DataManager.Instance.GameSettingPrefs.music);
        swapButton_Sound.Init(DataManager.Instance.GameSettingPrefs.sound);

        objButtonHome.SetActive(!isMainMenu);

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        swapButton_Music.onSwap -= OnSwapButton_Music;
        swapButton_Sound.onSwap -= OnSwapButton_Sound;
    }


    void OnSwapButton_Music(bool value)
    {
        DataManager.Instance.GameSettingPrefs.SetMusic(value);
        if (value)
        {
            AudioManager.Instance.PlayMusic();
        }
        else
        {
            AudioManager.Instance.StopMusic();
        }
    }
    void OnSwapButton_Sound(bool value)
    {
        DataManager.Instance.GameSettingPrefs.SetSound(value);
    }
    void OnSwapButton_Vibration(bool value)
    {
        DataManager.Instance.GameSettingPrefs.SetVibration(value);
    }

    void OnCheckBoxChanged(int id)
    {
        DataManager.Instance.GameSettingPrefs.SetQuality((QualityType)id);
    }

    public void ButtonClose()
    {
        Dismiss();
        onClose?.Invoke();
    }

    public void ButtonHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

}