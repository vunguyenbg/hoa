using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        PopupMainMenu.Show();
        AudioManager.Instance.PlayMusic_Lobby();
    }
}
