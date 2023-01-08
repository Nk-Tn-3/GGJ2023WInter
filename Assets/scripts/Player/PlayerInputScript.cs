using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    PlayerMovement player_movement;
    PlayerInteract player_interact;
    Player player_script;

    public void Start()
    {
    
        //player_interact = GetComponent<PlayerInteract>();
        player_script = GetComponent<Player>();
        player_movement = player_script.movement;
    }


    public void OnMovement(InputValue value)
    {
        //player_movement.UpdateDirection(value.Get<Vector2>());
        //player_script.UpdateDirection(value.Get<Vector2>());
        player_script.ReadMovementInput(value.Get<Vector2>());
       
    }

    public void OnInteract()
    {
        //player_interact.Interact();
        player_script.ReadInteract();
     
    }
}
