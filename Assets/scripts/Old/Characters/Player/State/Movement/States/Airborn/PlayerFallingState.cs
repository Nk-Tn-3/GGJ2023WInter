
using System;
using UnityEngine;

namespace PlayerMovementNS
{
    public class PlayerFallingState : PlayerAirbornState
    {
        private PlayerFallData fallData;
        public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            fallData = airborneData.FallData;
        }
        #region Istate Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = 0f;
            ResetVerticalVelocity();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            LimitVerticalVelocity();
        }

      

        #endregion

        #region Main Methods
        private void LimitVerticalVelocity()
        {
            Vector3 playerVerticalVelocity = GetPlayerVerticalVelocity();
            //Negative (-16<-15)
            if(playerVerticalVelocity.y >= -fallData.FallSpeedLimit)
            {
                return;
            }

            Vector3 limitedVelocity = new Vector3(0f, -fallData.FallSpeedLimit - playerVerticalVelocity.y, 0f);

            stateMachine.player.Rigidbody.AddForce(limitedVelocity, ForceMode.VelocityChange);

        }

        #endregion

        #region Reusable Methods

        protected override void ResetSprintState()
        {

        }
        #endregion
    }
}
