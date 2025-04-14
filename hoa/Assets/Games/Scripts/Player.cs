using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum HeroState
    {
        Idle,
        Move,
        Jump
    }

    [SerializeField] private Character character;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private CharacterHorizontalMovement  characterHorizontalMovement;
    [SerializeField] private CharacterJump characterJump;
    [SerializeField] private SkeletonAnimation anim;
    [SerializeField] private HeroState heroState;

    private void Start()
    {
        anim.state.Complete += AnimationComplete;
    }


    private void OnDestroy()
    {
        anim.state.Complete -= AnimationComplete;
    }

    private void AnimationComplete(TrackEntry trackentry)
    {
    }
    
    public void MoveLeft()
    {
        characterHorizontalMovement.SetHorizontalMove(-1f);
        ChangeState(HeroState.Move);
    }

    public void MoveRight()
    {
        characterHorizontalMovement.SetHorizontalMove(1f);
        ChangeState(HeroState.Move);
    }

    public void MoveStop()
    {
        characterHorizontalMovement.SetHorizontalMove(0);
        ChangeState(HeroState.Idle);
    }

    public void Jump()
    {
        characterJump.JumpStart();
        ChangeState(HeroState.Jump);
    }

    public void JumpStop()
    {
        ChangeState(HeroState.Idle);
    }
    public void ChangeState(HeroState newState)
    {
        if (heroState != newState)
        {
            heroState = newState;
            switch (heroState)
            {
                case HeroState.Idle:
                    SetAnimation("tho", true);
                    break;
                case HeroState.Move:
                    SetAnimation("chay", true);
                    break;
                case HeroState.Jump:
                    SetAnimation("nhay");
                    break;
            }
        }
    }

    void SetAnimation(string animationName, bool loop = false)
    {
        anim.state.SetAnimation(0, animationName, loop);
    }

    private void Update()
    {
        if (heroState == HeroState.Jump)
        {
            if (!character.Airborne)
            {
                if (characterHorizontalMovement._horizontalMovement > 0)
                {
                    ChangeState(HeroState.Move);
                }
                else if (characterHorizontalMovement._horizontalMovement < 0)
                {
                    ChangeState(HeroState.Move);
                }
                else
                {
                    ChangeState(HeroState.Idle);
                }
            }
        }
    }
}
