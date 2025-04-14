
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BayatGames.SaveGameFree;

public class ClearData : EditorWindow
{
    [MenuItem("ClearData/ClearData")]
    static void Clear_Data()
   {
        SaveGame.DeleteAll();
        PlayerPrefs.DeleteAll();
    }
#if UNITY_I2
    [MenuItem("Language/English")]
    static void English()
    {
        I2.Loc.LocalizationManager.CurrentLanguage = "English";
    }
    [MenuItem("Language/VietNamese")]
    static void VietNamese()
    {
        I2.Loc.LocalizationManager.CurrentLanguage = "VietNamese";
    }
#endif
}
#endif
