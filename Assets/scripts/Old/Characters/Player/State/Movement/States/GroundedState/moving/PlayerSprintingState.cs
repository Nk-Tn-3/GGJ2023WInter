using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{
    public class PlayerSprintingState : PlayerMovingState
    {
        private PlayerSprintData sprintData;

        private float startTime;
        public bool keepSrpinting;
        public bool resetSprintState;
        public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            sprintData = movementData.SprintData;  
        }

        #region Istate Methods

        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementSpeedModifier = sprintData.SpeedModifier;
            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

            resetSprintState = true;
            startTime = Time.time;

         
        }

        public override void Exit()
        {
            base.Exit();
            keepSrpinting = false;

            if (resetSprintState)
            {
                keepSrpinting = false;
                stateMachine.ReusableData.ToggleSprint = false;
            }
        }


        public override void Update()
        {
            base.Update();
            if (keepSrpinting) return;

            if (Time.time < startTime + sprintData.SprintToRunTime)
            {
                return;//not the time to transition to run state
            }
            StopSprinting();
        }
        #endregion

        #region Main Methods
        private void StopSprinting()
        {
            //no input(stop)
            if(stateMachine.ReusableData.MovementInput == Vector2.zero)//transition to stop state
            {
                stateMachine.ChangeState(stateMachine.idlingState);
                return;
            }
            //input continues(run)
            stateMachine.ChangeState(stateMachine.runningState);
        }
        #endregion


        #region Reusable Methods

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.player.input.playerActions.Sprint.performed += OnSprintPerformed;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            stateMachine.player.input.playerActions.Sprint.performed -= OnSprintPerformed;
        }

        protected override void OnFall()
        {
            resetSprintState = false;
            base.OnFall();
        }

        #endregion


        #region Input Methods
        private void OnSprintPerformed(InputAction.CallbackContext context)
        {
            keepSrpinting = true;
            stateMachine.ReusableData.ToggleSprint = true;
        }
        protected override void OnJumpStarted(InputAction.CallbackContext context)
        {
            resetSprintState = false;
            base.OnJumpStarted(context);
        }
        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.hardStoppingState);
            base.OnMovementCanceled(context);
        }
        #endregion
    }
}
