

using Yoolax.Framework;
using System;

[Serializable]
public class DayPrefs : BasePrefs
{
    public long firstTimeOpenApp;
    public int day;
    public string dayToString;
    public bool firstOpenApp;

    public DayPrefs(long _firstTimeOpenApp, int _day)
    {
        this.firstTimeOpenApp = _firstTimeOpenApp;
        this.day = _day;
        firstOpenApp = true;
        DataManager.Instance.isNextDay = true;

#if UNITY_EDITOR
        dayToString = DateTime.FromBinary(firstTimeOpenApp).ToString();
#endif
    }

    public override void OnLoad()
    {
        DataManager.Instance.isShowAdsOpenApp = true;
        if (DataManager.Instance.DayPrefs.firstTimeOpenApp == 0)
        {
            DataManager.Instance.DayPrefs.firstTimeOpenApp = DataManager.Instance.GetTimeNow().ToBinary();
#if UNITY_EDITOR
            DataManager.Instance.DayPrefs.dayToString = DateTime.FromBinary(DataManager.Instance.DayPrefs.firstTimeOpenApp).ToString();
#endif
        }

        DateTime preTime = DateTime.FromBinary(DataManager.Instance.DayPrefs.firstTimeOpenApp);
        DateTime currentTime = DataManager.Instance.GetTimeNow();
        if (currentTime.Year > preTime.Year || currentTime.Month > preTime.Month || currentTime.Day > preTime.Day)
        {
            DataManager.Instance.isNextDay = true;
            DataManager.Instance.DayPrefs.day++;
            DataManager.Instance.DayPrefs.firstTimeOpenApp = DataManager.Instance.GetTimeNow().ToBinary();
        }
    }
    public bool IsFirstOpenApp()
    {
        if (firstOpenApp)
        {
            firstOpenApp = false;
            return true;
        }
        return false;
    }
}
