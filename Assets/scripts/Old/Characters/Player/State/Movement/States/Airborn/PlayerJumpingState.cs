
using System;
using UnityEngine;

namespace PlayerMovementNS
{
    public class PlayerJumpingState : PlayerAirbornState
    {
        private bool keepRotating;
        private PlayerJumpData jumpData;

        //you can only fall once (not in real life)
        private bool canFall;
        public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            jumpData = airborneData.JumpData;
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.RotationData = jumpData.RotationData;
            
            stateMachine.ReusableData.MovementSpeedModifier = 0f;
            stateMachine.ReusableData.MovementDecelerationForce = jumpData.DecelerationForce;
            
            
            keepRotating = stateMachine.ReusableData.MovementInput != Vector2.zero;
            Jump();
        }
        public override void Exit()
        {
            base.Exit();
            canFall = false;
            SetBaseRotationData();
        }
        public override void Update()
        {
            base.Update();

            if (!canFall && IsMovingUp(0f))
            {
                canFall = true;
            }
            if (!canFall || GetPlayerVerticalVelocity().y > 0) return;

            stateMachine.ChangeState(stateMachine.fallingState);
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (keepRotating)
            {
                RotateTowardsTargetRotation();
              
            }

            //floaty jump fix
            if (IsMovingUp())
            {
                DecelerateVertically();
            }
        }
   

        #endregion




        #region Main Methods
        private void Jump()
        {
            Vector3 jumpForce = stateMachine.ReusableData.CurrentJumpForce;

            Vector3 jumpDirection = stateMachine.player.transform.forward;

            if (keepRotating)
            {
                UpdateTargetRotation(GetMovementInputDirection());
                jumpDirection = GetTargetRotationDirection(stateMachine.ReusableData.CurrentTargetRotation.y);
            }
            
            jumpForce.x *= jumpDirection.x;
            jumpForce.z *= jumpDirection.z;
            
            //Checking slope
            Vector3 capsuleColliderCenterInWorldSpace = stateMachine.player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;
            Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);
            if (Physics.Raycast(downwardsRayFromCapsuleCenter,out RaycastHit hit,jumpData.JumpToGroundDistance,stateMachine.player.LayerData.GroundLayer,QueryTriggerInteraction.Ignore))
            {
                float groundAngle = Vector3.Angle(hit.normal, -downwardsRayFromCapsuleCenter.direction);
                if (IsMovingUp())
                {
                    float forceModifier = jumpData.JumpForceModifierUpwardSlope.Evaluate(groundAngle);
                    jumpForce.x *= forceModifier;
                    jumpForce.z *= forceModifier;
                
                }

                if (IsMovingDown())
                {
                    float forceModifier = jumpData.JumpForceModifierDownwardSlope.Evaluate(groundAngle);
                    jumpForce.y *= forceModifier;
                }
            
            
            }



            ResetVelocity();

            stateMachine.player.Rigidbody.AddForce(jumpForce, ForceMode.VelocityChange);
        }
        #endregion


        #region ReusableMethods
        

        //Remove sprint reset from jumping
        protected override void ResetSprintState()
        {
            return;    
        }

        
        #endregion
    }
}
