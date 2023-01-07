
using UnityEngine;
using UnityEngine.InputSystem;
namespace PlayerMovementNS
{
    public class PlayerWalkingState : PlayerMovingState
    {
        public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }


        #region Istate Methods

        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = movementData.WalkData.SpeedModifier;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.WeakForce;
        }
        #endregion





        #region Input Methods
        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.runningState);
        }


        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.lightStoppingState);
        }


        #endregion


    }
}
