using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerInputActions inputActions { get; private set; }
        public PlayerInputActions.PlayerActions playerActions { get; private set; }
        private void Awake()
        {
            inputActions = new PlayerInputActions();
            playerActions = inputActions.Player;
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
