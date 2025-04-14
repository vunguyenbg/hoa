using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance;
    [SerializeField] private Player playerTemp;
     private LevelManager levelManager;
    private Player player;
    [SerializeField] private bool isUsingButtonInput;
    [SerializeField] private int level = 1;
    [SerializeField] private GameObject[] maps;
    [SerializeField] private GameObject map;

    private void Awake()
    {
        Instance = this;
        playerTemp.gameObject.SetActive(false);
    }

    private void Start()
    {
        SpawnMap();
        isUsingButtonInput = false;
        PopupGamePlay.Show();
        AudioManager.Instance.PlayMusic_InGame();
    }

    public void NextLevel()
    {
        if (level < maps.Length)
        {
            level++;
        }

        SpawnMap();
    }
    void SpawnMap()
    {
        int id = level - 1;
        if (id < 0)
        {
            id = 0;
        }
        else if (id > maps.Length - 1)
        {
            id = maps.Length - 1;
        }

        if (map != null)
        {
            Destroy(map);
        }
        map = Instantiate(maps[id]);
        levelManager = map.GetComponent<Map>().levelManager;

        if (player != null)
        {
            player.gameObject.SetActive(false);
        }
        StartCoroutine(DelayEndOfFrame( () =>
        {
            player = levelManager.playerTemp.GetComponent<Player>(); 
        }));
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
