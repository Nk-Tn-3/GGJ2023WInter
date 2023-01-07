using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace PlayerMovementNS
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerInputActions inputActions { get; private set; }
        public PlayerInputActions.PlayerActions playerActions { get; private set; }
        public PlayerInputActions.Player2Actions playerActions2 { get; private set; }
        private void Awake()
        {
            inputActions = new PlayerInputActions();
            if (gameObject.CompareTag("Player2"))
            {
                playerActions2 = inputActions.Player2;
            }
            else
            {
                playerActions = inputActions.Player;
            }
        
        }



        public Vector2 GetMovement()
        {
            if (gameObject.CompareTag("Player2"))
            {
                return playerActions2.Movement.ReadValue<Vector2>();
            }
            return playerActions.Movement.ReadValue<Vector2>();
        }

        public bool GetPickTrigger()
        {
            if (gameObject.CompareTag("Player2"))
            {
                return playerActions2.PickUp.triggered;
            }
            return playerActions.PickUp.triggered;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void DisableActionTime(InputAction action, float time)
        {
            StartCoroutine(DisableAction(action, time));
        }


        private IEnumerator DisableAction(InputAction action, float time)
        {
            action.Disable();
            yield return new WaitForSeconds(time);
            action.Enable();
        }
    }
}
