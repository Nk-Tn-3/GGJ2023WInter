using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{
    public class PlayerStoppingState : PlayerGroundedState
    {
        public PlayerStoppingState(PlayerMovementStateMachine playerMovementStateMachine): base(playerMovementStateMachine)
        {


        }

        #region Istate methdos
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = 0f;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


            RotateTowardsTargetRotation();

            if (!IsMovingHorizontal()) return;


            DecelerateHorizontally();
        }

        public override void OnAnimationTransitionEvent()
        {
      
            stateMachine.ChangeState(stateMachine.idlingState);
        }
        #endregion

        #region Reusable methdos
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.player.input.playerActions.Movement.started += onMovementStarted;
        }

  

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            stateMachine.player.input.playerActions.Movement.started -= onMovementStarted;
        }
        #endregion

        #region Input Methods
        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            
        }

        private void onMovementStarted(InputAction.CallbackContext context)
        {
            //transition to move state
            onMove();
        }
        #endregion
    }
}
