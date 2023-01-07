using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{
    public class PlayerRunningState : PlayerMovingState
    {
        private float startTime;
        //To enter to walk from sprint
        private PlayerSprintData sprintData;
        public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            sprintData = movementData.SprintData;
        }
        #region Istate Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = movementData.RunData.SpeedModifier;
            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.MediumForce;
            startTime = Time.time;
        }
        public override void Update()
        {

            //change from run to walk(mostly from dashing from walk)
            base.Update();
            if (!stateMachine.ReusableData.ToggleWalk)
            {
                return;
            }

            if(Time.time<startTime+sprintData.RunToWalkTime)
            {
                return;
                
            }
            StopRunning();
        }


        #endregion

        #region Main Mehods
        private void StopRunning()
        {
           if(stateMachine.ReusableData.MovementInput== Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.idlingState);
                return;
            }
            stateMachine.ChangeState(stateMachine.walkingState);
        }
        #endregion
        #region Reusable Methods

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            stateMachine.player.input.playerActions.Movement.canceled += OnMovementCanceled;
        }
        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.player.input.playerActions.Movement.canceled -= OnMovementCanceled;
        }



        #endregion


        #region Input Methods
        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.walkingState);
        }
        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.mediumStoppingState);
        }


        #endregion
    }
}
