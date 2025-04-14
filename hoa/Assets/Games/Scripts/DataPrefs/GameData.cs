using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public DayPrefs DayPrefs;
    public GameSettingPrefs GameSettingPrefs;
    public GameCurrencyPrefs GameCurrencyPrefs;
    public void LoadData()
    {
        if (DayPrefs == null)
        {
            DayPrefs = new DayPrefs(DataManager.Instance.GetTimeNow().ToBinary(), 0);
        }

        if (GameSettingPrefs == null)
        {
            GameSettingPrefs = new GameSettingPrefs(true, true, false, QualityType.Medium);
        }
        if (GameCurrencyPrefs == null)
        {
            GameCurrencyPrefs = new GameCurrencyPrefs(1000, 100, 10);
        }


        OnLoad();
    }
    void OnLoad()
    {
        DayPrefs.OnLoad();
        GameCurrencyPrefs.OnLoad();

    }
    public void OnSave()
    {
        DayPrefs.OnSave();
        GameCurrencyPrefs.OnSave();

    }
}
