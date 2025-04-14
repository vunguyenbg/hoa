using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterHorizontalMovement  characterHorizontalMovement;
    [SerializeField] private CharacterJump characterJump;
    public void MoveLeft()
    {
        characterHorizontalMovement.SetHorizontalMove(-1f);
    }

    public void MoveRight()
    {
        characterHorizontalMovement.SetHorizontalMove(1f);
    }

    public void MoveStop()
    {
        characterHorizontalMovement.SetHorizontalMove(0);
    }

    public void Jump()
    {
        characterJump.JumpStart();
    }
}
