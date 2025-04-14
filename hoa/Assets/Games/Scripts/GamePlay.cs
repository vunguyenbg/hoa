using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Player playerTemp;
    [SerializeField] private LevelManager levelManager;
    private Player player;
    [SerializeField] private bool isUsingButtonInput;

    private void Awake()
    {
        playerTemp.gameObject.SetActive(false);
    }

    private void Start()
    {
        isUsingButtonInput = false;
        StartCoroutine(DelayEndOfFrame( () =>
        {
            player = levelManager.playerTemp.GetComponent<Player>(); 
        }));
        PopupGamePlay.Show();
    }

    public void ButtonMoveLeft()
    {
        isUsingButtonInput = true;
        player.MoveLeft();
    }

    public void ButtonMoveRight()
    {
        isUsingButtonInput = true;
        player.MoveRight();
    }

    public void ButtonMoveStop()
    {
        isUsingButtonInput = false;
        player.MoveStop();
    }

    public void ButtonJump()
    {
        player.Jump();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (isUsingButtonInput)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player.MoveRight();
        }
        else if (Input.GetKeyUp(KeyCode.A)
                  || Input.GetKeyUp(KeyCode.D))
        {
            player.MoveStop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }
#endif
    }

    IEnumerator DelayEndOfFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action();
    }
    IEnumerator Delay(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
