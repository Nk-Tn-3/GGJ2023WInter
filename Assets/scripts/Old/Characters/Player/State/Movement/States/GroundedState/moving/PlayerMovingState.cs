
using UnityEngine;

namespace PlayerMovementNS
{
    public class PlayerMovingState : PlayerGroundedState
    {
        public PlayerMovingState(PlayerMovementStateMachine  playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }
    }
}
