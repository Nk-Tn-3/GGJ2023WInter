using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PlayerMovementNS
{
    public class PlayerGroundedState : PlayerMovementState
    {
        private SlopeData slopeData;
        public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            slopeData = stateMachine.player.ColliderUtility.SlopeData;
        
        }

        #region IStateMethods
        public override void Enter()
        {
            base.Enter();
            //When lands and no input pressed - reset Sprinting
            UpdateSprintToggle();
        }

    

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Float();
        }

      

        #endregion
        #region Main Methods
        private void Float()
        {
            Vector3 capsuleColliderCenterInWorldSpace = stateMachine.player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

            Ray downRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

            if(Physics.Raycast(downRayFromCapsuleCenter,out RaycastHit hit,slopeData.RayDistance,stateMachine.player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
            {
                float groundAngle = Vector3.Angle(hit.normal, -downRayFromCapsuleCenter.direction);
                float slopeSpeedModifier = SetSlopeSpeedModifierAngle(groundAngle);

                if (slopeSpeedModifier == 0f) return;

                float distanceToFloatingPoint = stateMachine.player.ColliderUtility.CapsuleColliderData.ColliderCenterInLocalSpace.y*stateMachine.player.transform.localScale.y-hit.distance;
                
               
                
                if(distanceToFloatingPoint == 0f ) return;
              
                float amountToLift = distanceToFloatingPoint*slopeData.StepReachForce-GetPlayerVerticalVelocity().y;
                Vector3 liftForce = new Vector3(0f, amountToLift, 0f);
                stateMachine.player.Rigidbody.AddForce(liftForce, ForceMode.VelocityChange);
            
            }
        }
        private void UpdateSprintToggle()
        {
            if (!stateMachine.ReusableData.ToggleSprint) return;

            if (stateMachine.ReusableData.MovementInput != Vector2.zero) return;

            stateMachine.ReusableData.ToggleSprint = false;
        }

        private float SetSlopeSpeedModifierAngle(float angle)
        {
            float slopeSpeedModifier = movementData.SlopeAngles.Evaluate(angle);
            stateMachine.ReusableData.MovementOnSlopeSpeedModifier = slopeSpeedModifier;

            return slopeSpeedModifier;
        }


        private bool isThereGroundUnder()
        {
            BoxCollider groundCheckCollider = stateMachine.player.ColliderUtility.triggerColliderData.GroundCheckCollider;


            Vector3 groundColliderCenterWorldSpace = groundCheckCollider.bounds.center;
            Collider[] overlappedGroundColliders = Physics.OverlapBox(groundColliderCenterWorldSpace, groundCheckCollider.bounds.extents,groundCheckCollider.transform.rotation,stateMachine.player.LayerData.GroundLayer,QueryTriggerInteraction.Ignore);

            return overlappedGroundColliders.Length > 0;
        }
        #endregion
        #region Reusable Methods
        protected virtual void onMove()
        {
            if (stateMachine.ReusableData.ToggleSprint)
            {
                stateMachine.ChangeState(stateMachine.sprintingState);
                return;
            }
            if (stateMachine.ReusableData.ToggleWalk)
            {
                stateMachine.ChangeState(stateMachine.walkingState);
                return;
            }

            stateMachine.ChangeState(stateMachine.runningState);
        }

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            stateMachine.player.input.playerActions.Movement.canceled += OnMovementCanceled;

            if(movementData.RestrictionData.CanDash) stateMachine.player.input.playerActions.Dash.started += OnDashStarted;
            if (movementData.RestrictionData.CanJump) stateMachine.player.input.playerActions.Jump.started += OnJumpStarted;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.player.input.playerActions.Movement.canceled -= OnMovementCanceled;
            stateMachine.player.input.playerActions.Dash.started -= OnDashStarted;
            stateMachine.player.input.playerActions.Jump.started -= OnJumpStarted;
        }


        protected override void OnContactWithGroundExited(Collider collider)
        {
           
            base.OnContactWithGroundExited(collider);

            if (isThereGroundUnder()) return;
           

            Vector3 capsuleColliderCenterWorldSpace = stateMachine.player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;
            Ray downwardsRayFromCapsuleBottom = new Ray(capsuleColliderCenterWorldSpace-stateMachine.player.ColliderUtility.CapsuleColliderData.ColliderVerticalExtents, Vector3.down);

            
            if (!Physics.Raycast(downwardsRayFromCapsuleBottom, out _, movementData.GroundToFallRayDistance, stateMachine.player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
            {
                OnFall();
            }
        }


        protected virtual void OnFall()
        {
            stateMachine.ChangeState(stateMachine.fallingState);
        }
        #endregion

        #region Input Methods

        protected virtual void OnDashStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.dashingState);
        }
        protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.idlingState);
        }


        protected virtual void OnJumpStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.jumpingState);
        }

        #endregion

    }
}
