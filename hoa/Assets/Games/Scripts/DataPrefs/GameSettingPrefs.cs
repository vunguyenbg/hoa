
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Yoolax.Framework;

public enum QualityType
{
    Low,
    Medium,
    High,
    Untra
}
[System.Serializable]
public class GameSettingPrefs : BasePrefs
{
    public bool music;
    public bool sound;
    public bool vibration;
    public QualityType qualityType;

    public GameSettingPrefs(bool music, bool sound, bool vibration, QualityType qualityType)
    {
        this.music = music;
        this.sound = sound;
        this.vibration = vibration;
        this.qualityType = qualityType;
    }

    public override void OnLoad()
    {
    }

    public void SetMusic(bool value)
    {
        this.music=value;
    }
    public void SetSound(bool value)
    {
        this.sound = value;
    }
    public void SetVibration(bool value)
    {
        this.vibration = value;
    }
    public void SetQuality(QualityType value)
    {
        this.qualityType = value;
    }

}
