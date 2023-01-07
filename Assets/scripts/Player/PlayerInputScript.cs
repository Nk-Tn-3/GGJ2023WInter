using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    PlayerMovement player_movement;

    public void Start()
    {
        player_movement = GetComponent<PlayerMovement>();
    }

    public void OnMovement(InputValue value)
    {
        player_movement.UpdateDirection(value.Get<Vector2>());
    }
}
