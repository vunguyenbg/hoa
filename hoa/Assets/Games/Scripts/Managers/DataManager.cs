
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using Yoolax.Framework;

public class DataManager : SingletonDontDestroy<DataManager>
{
    private string dataKey = "dataKey";
    [SerializeField] private GameData gameData;
    [SerializeField] private GameDataFileStream gameDataFileStream;

    public DayPrefs DayPrefs { set => gameData.DayPrefs = value; get => gameData.DayPrefs; }
    public GameSettingPrefs GameSettingPrefs { set => gameData.GameSettingPrefs = value; get => gameData.GameSettingPrefs; }
    public GameCurrencyPrefs GameCurrencyPrefs { set => gameData.GameCurrencyPrefs = value; get => gameData.GameCurrencyPrefs; }


    public Action OnSave;

    public bool isNextDay;
    public bool isShowAdsOpenApp;
    public bool isTestTime;

    public override void Awake()
    {
        base.Awake();
        LoadData();
    }
    public void LoadData()
    {
        gameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(dataKey));
        if (gameData == null)
        {
            gameData = new GameData();
        }

        //Load File Stream
        gameDataFileStream = SaveGame.Load<GameDataFileStream>(dataKey);
        if (gameDataFileStream == null)
        {
            gameDataFileStream = new GameDataFileStream();
        }


        gameData.LoadData();
        gameDataFileStream.LoadData();
    }
    public void OnSaveData()
    {
        if (OnSave != null)
        {
            OnSave();
        }
        gameData.OnSave();
        // gameDataFileStream.OnSave();
        PlayerPrefs.SetString(dataKey, JsonUtility.ToJson(gameData));
        SaveGame.Save(dataKey, gameDataFileStream);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnSaveData();
        }
    }
    private void OnApplicationQuit()
    {
        OnSaveData();
    }

    public DateTime GetTimeNow()
    {
        if (isTestTime)
        {
            return System.DateTime.Now;

        }
        else
        {
            //return UnbiasedTime.Instance.Now();
            return System.DateTime.Now;

        }
    }
    public DateTime GetTimeUTCNow()
    {
        if (isTestTime)
        {
            return System.DateTime.Now;

        }
        else
        {
            //return UnbiasedTime.Instance.Now();
            return System.DateTime.Now;

        }
    }
}
