using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCheckBox : MonoBehaviour
{
    public Action<int> onCheckBoxChanged;
    [SerializeField] private List<CheckBoxItem> lstCheckBoxItem;

    public int selectedID;

    public void Init(int selectedID)
    {
        this.selectedID = selectedID;
        UpdateUI();


    }
    void UpdateUI()
    {
        for (int i = 0; i < lstCheckBoxItem.Count; i++)
        {
            if (i == this.selectedID)
            {
                lstCheckBoxItem[i].Init(i, true, OnClickToCheckBox);
            }
            else
            {
                lstCheckBoxItem[i].Init(i, false, OnClickToCheckBox);
            }
        }
    }

    public void OnClickToCheckBox(int id)
    {
        if (selectedID != id)
        {
            selectedID = id;
            onCheckBoxChanged?.Invoke(selectedID);
            UpdateUI();
        }
    }
}
