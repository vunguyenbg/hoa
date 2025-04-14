

using Yoolax.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : SingletonDontDestroy<AudioManager>
{

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sound;

    [SerializeField] private AudioClip[] musicLobbyClips;
    [SerializeField] private AudioClip[] musicInGameClips;

    [SerializeField] private AudioClip buttonClip;

    public void PlayMusic_Lobby()
    {
        if (DataManager.Instance.GameSettingPrefs.music)
        {
            StopMusic();
            music.clip = GetMusic_Lobby();
            music.loop = true;
            music.Play();
        }
    }
    public void PlayMusic_InGame()
    {
        if (DataManager.Instance.GameSettingPrefs.music)
        {
            StopMusic();
            music.clip = GetMusic_InGame();
            music.loop = true;
            music.Play();
        }
    }
    public void PlayMusic()
    {
        music.Play();
    }
    public void StopMusic()
    {
        music.Stop();
    }
    AudioClip GetMusic_Lobby()
    {
        return musicLobbyClips[Random.Range(0, musicLobbyClips.Length)];
    }
    AudioClip GetMusic_InGame()
    {
        return musicInGameClips[Random.Range(0, musicInGameClips.Length)];
    }

    public void PlayAudio_Button()
    {
        if (buttonClip == null)
            return;
        if (DataManager.Instance.GameSettingPrefs.sound)
        {
            sound.PlayOneShot(buttonClip);
        }
    }
}
