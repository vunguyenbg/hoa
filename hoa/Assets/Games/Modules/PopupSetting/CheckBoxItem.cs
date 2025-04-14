using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxItem : MonoBehaviour
{
    [SerializeField] private GameObject objTick;
    private Action<int> onClickCheckBox;

    private bool isOn;
    private int id;
    public void Init(int id, bool isOn, Action<int> onClickCheckBox)
    {
        this.id = id;
        this.isOn = isOn;
        this.onClickCheckBox = onClickCheckBox;

        UpdateUI();
    }
    void UpdateUI()
    {
        objTick.SetActive(isOn);
    }
    public void ButtonClick()
    {
        if (!isOn)
        {
            isOn = true;
            onClickCheckBox?.Invoke(id);
            UpdateUI();
        }
    }
}
