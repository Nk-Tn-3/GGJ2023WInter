using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player player { get; }




   public PlayerMovementStateMachine(Player player)
    {
        this.player = player;
    }




}
