using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationController 

{
    private bool isWalking;
    private bool isIdle;

    
    private bool isLocked;
    private bool isPickingUp;

    private Vector2 movement;
    Animator animator;


    public void Initizalize(Animator controller)
    {
        animator = controller;
    }
    public void Update(Vector2 movement,bool pick)
    {
        this.movement = movement;
        isPickingUp= pick;
        TryPlayAnim();
        Debug.Log(movement);
    }


    private void TryPlayAnim()
    {
        if(isLocked) return;
        if (isPickingUp)
        {
            animator.SetTrigger("PickUp");
            return;
        }
        if (movement == Vector2.zero)
        {
            Idle();
        }
        else
        {
            Move();
        }


        animator.SetBool("Idle", isIdle);
        animator.SetBool("Move", isWalking);
    }


    private void Move()
    {
        if (!isIdle && isWalking) return;

        isIdle = false;
        isWalking= true;
        
    }

    private void Idle()
    {
        if (isIdle && !isWalking) return;

        isIdle = true;
        isWalking = false;


    }

    public void PickUpStart()
    {
        isLocked = true;
        isIdle = false;
        isWalking = false;
        animator.SetBool("Idle", isIdle);
        animator.SetBool("Move", isWalking);
    }

    public void PickUpEnd() {
        isLocked = false;
    }





}
