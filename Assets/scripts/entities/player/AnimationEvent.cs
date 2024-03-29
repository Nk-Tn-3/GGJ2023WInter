using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] Player player;


    public void OnAnimationEnter()
    {
        player.AnimationEnterEvent();
    }

    public void onAnimationExit() { player.AnimationExitEvent(); }

    public void PickUpEnter()
    {
        player.PikcUpColliderEnterEvent();
    }


    public void Throw()
    {
        player.Throw(); 
    }
}
