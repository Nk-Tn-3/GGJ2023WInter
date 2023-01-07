
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{
    public class PlayerDashingState : PlayerGroundedState
    {
       
        private PlayerDashData dashData;

        private float startTime;
        private int consecutiveDashesUsed;


        private bool keepRotating;
        public PlayerDashingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            dashData = movementData.DashData;
        }

        #region Istate methods
        public override void Enter()
        {
            base.Enter();

            
            stateMachine.ReusableData.MovementSpeedModifier = dashData.SpeedModifier;
            //If moves increase speedmultiplier, if stopped - AddForce
            //stopped state
            stateMachine.ReusableData.RotationData = dashData.RotationData;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

            AddForceOnTrasnitionFromStationaryState();
            keepRotating = stateMachine.ReusableData.MovementInput != Vector2.zero;

            UpdateConsecutiveDashes();

            startTime = Time.time;

        }

        public override void Exit()
        {
            base.Exit();
            SetBaseRotationData();
        }
        public override void Update()
        {
            base.Update();
            
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (!keepRotating) return;


            RotateTowardsTargetRotation();
        }

        public override void OnAnimationTransitionEvent()
        {
            
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.hardStoppingState);
                return;
            }

            stateMachine.ChangeState(stateMachine.sprintingState);
        }
        #endregion


        #region Main Methods
        private void AddForceOnTrasnitionFromStationaryState()
        {
            
            if (stateMachine.ReusableData.MovementInput != Vector2.zero) return;

            
            Vector3 characterRotationDirection = stateMachine.player.transform.forward;
            //only need horizontal
            characterRotationDirection.y = 0f;

            UpdateTargetRotation(characterRotationDirection,false);

            stateMachine.player.Rigidbody.velocity = characterRotationDirection * GetMovementSpeed();
        
        }

        private void UpdateConsecutiveDashes()
        {
            if (!IsConsecutive())
            {
                consecutiveDashesUsed = 0;
            }

            ++consecutiveDashesUsed;
            if (consecutiveDashesUsed == dashData.ConsecutiveDashesLimitAmount)
            {
                consecutiveDashesUsed = 0;

                //disable input
                stateMachine.player.input.DisableActionTime(stateMachine.player.input.playerActions.Dash, dashData.DashLimitReachedCooldown);
            }
        }

        private bool IsConsecutive()
        {
            return Time.time < startTime + dashData.TimeToBeConsideredConsecutive;
        }
        #endregion
        #region Reusable methods
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            stateMachine.player.input.playerActions.Movement.performed += OnMovementPerformed;
        }

       
        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            stateMachine.player.input.playerActions.Movement.performed -= OnMovementPerformed;

        }
        #endregion

        #region Input Methods

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            keepRotating = true;
        }

        protected override void OnDashStarted(InputAction.CallbackContext context)
        {
            
        }

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
          
        }
        #endregion
    }
}
