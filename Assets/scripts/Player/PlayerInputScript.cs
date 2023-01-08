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
        /*player_movement = GetComponent<PlayerMovement>();
        player_interact = GetComponent<PlayerInteract>();*/
        player_script = GetComponent<Player>();
    }

    public void OnMovement(InputValue value)
    {
        //player_movement.UpdateDirection(value.Get<Vector2>());
        //player_script.UpdateDirection(value.Get<Vector2>());
        print("movin");
    }

    public void OnInteract()
    {
        //player_interact.Interact();
        //player_script.UpdateInteract();
        print("pickin");
    }
}
