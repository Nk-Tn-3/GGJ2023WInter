using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovementNS
{
    public class PlayerHardStoppingState : PlayerStoppingState
    {
        public PlayerHardStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region Istate methods
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.HardDecelerationForce;
            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

        }
        #endregion


        #region Reusable Methods
        protected override void onMove()
        {
            if (stateMachine.ReusableData.ToggleWalk) return;

            stateMachine.ChangeState(stateMachine.runningState);
        }

        #endregion
    }
}
