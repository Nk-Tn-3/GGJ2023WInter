
using UnityEngine;

namespace PlayerMovementNS
{
    public class PlayerAirbornState : PlayerMovementState
    {
        public PlayerAirbornState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region Istate Methods
        public override void Enter()
        {
            base.Enter();

            //Cancel sprint when gliding(takes out this in jump and fall)
            ResetSprintState();
        }
        #endregion

        #region Reusable Methods



        protected override void OnContactWithGround(Collider collider)
        {
           
            stateMachine.ChangeState(stateMachine.idlingState);
        }


        protected virtual void ResetSprintState()
        {
            stateMachine.ReusableData.ToggleSprint = false;
        }

        #endregion

    }
}
