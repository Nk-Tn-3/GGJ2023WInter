using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    PlayerMovement player_movement;
    PlayerInteract player_interact;

    public void Start()
    {
        player_movement = GetComponent<PlayerMovement>();
        player_interact = GetComponent<PlayerInteract>();
    }

    public void OnMovement(InputValue value)
    {
        //player_movement.UpdateDirection(value.Get<Vector2>());
    }

    public void OnInteract()
    {
        player_interact.Interact();
    }
}
