using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerNS;
namespace PlayerMovementNS
{
    public class PlayerMovementStateMachine : StateMachine
    {

        public Player player { get; }
        public PlayerStateReusableData ReusableData { get; }

        
        public PlayerIdlingState idlingState { get;  }
        public PlayerWalkingState walkingState { get; }
        public PlayerRunningState runningState { get; }
        public PlayerSprintingState sprintingState { get;  }

        public PlayerDashingState dashingState { get; }


        //stopping
        public PlayerLightStoppingState lightStoppingState { get; }
        public PlayerMediumStoppingState mediumStoppingState { get; }
        public PlayerHardStoppingState hardStoppingState { get; }

        public PlayerJumpingState jumpingState { get; }
        public PlayerFallingState fallingState { get; }
        public PlayerMovementStateMachine(Player player)
        {
            this.player = player;
            ReusableData = new PlayerStateReusableData();
            idlingState = new PlayerIdlingState(this);


            walkingState = new PlayerWalkingState(this);
            runningState = new PlayerRunningState(this);
            sprintingState = new PlayerSprintingState(this);

            dashingState = new PlayerDashingState(this);


            lightStoppingState = new PlayerLightStoppingState(this);
            mediumStoppingState = new PlayerMediumStoppingState(this);
            hardStoppingState = new PlayerHardStoppingState(this);

            jumpingState = new PlayerJumpingState(this);
            fallingState = new PlayerFallingState(this);
        }
        
    }
}
