
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovementNS
{

    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;


        protected PlayerGroundedData movementData;
        protected PlayerAirborneData airborneData;




    
      


        //camera rotation






    

        public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine;

            movementData = stateMachine.player.playerData.GroundedData;
            airborneData = stateMachine.player.playerData.AirborneData;
            
            
            InitializeData();
        }

        


        private void InitializeData()
        {

            SetBaseRotationData();
        }

    




        //Interface methods(enter,exit...)
        #region State Methods

        public virtual  void Enter()
        {
            Debug.Log("State: " + GetType().Name);
            AddInputActionsCallbacks();
        }

    

        public virtual  void Exit()
        {
            RemoveInputActionsCallbacks();
        }

     

        public  virtual void HandleInput()
        {
            ReadMovementInput();
        }

        public  virtual void PhysicsUpdate()
        {
            Move();
        }

        public virtual  void Update()
        {
            
        }

        public virtual void OnAnimationEnterEvent()
        {

        }

        public virtual void OnAnimationExitEvent()
        {

        }
        public virtual void OnAnimationTransitionEvent()
        {

        }

        public virtual void OnTriggerEnter(Collider collider)
        {
            if (stateMachine.player.LayerData.IsGroundLayer(collider.gameObject.layer)){
                OnContactWithGround(collider);
                return;
            }
        }
        public virtual void OnTriggerExit(Collider collider)
        {
            if (stateMachine.player.LayerData.IsGroundLayer(collider.gameObject.layer))
            {
                OnContactWithGroundExited(collider);
                return;
            }
        }

      

        #endregion
        #region Main Methods
        private float Rotate(Vector3 direction)
        {
            float directionAngle = UpdateTargetRotation(direction);
            RotateTowardsTargetRotation();

            return directionAngle;
        }

        
        private float AddCameraRotationAngle(float angle)
        {
            angle += stateMachine.player.MainCameraTransform.eulerAngles.y;

            if (angle > 360f)
            {
                angle -= 360f;
            }

            return angle;
        }

        private float GetDirectionAngle(Vector3 direction)
        {
            float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            if (directionAngle <= 0)
            {
                directionAngle += 360f;
            }

            return directionAngle;
        }

        private void ReadMovementInput()
        {
            stateMachine.ReusableData.MovementInput = stateMachine.player.input.playerActions.Movement.ReadValue<Vector2>();
        }
        private void Move()
        {
            if(stateMachine.ReusableData.MovementInput== Vector2.zero || stateMachine.ReusableData.MovementSpeedModifier == 0)
            {
                return;
            }

            Vector3 movementDirection = GetMovementInputDirection();

            float targetRotationYAngle = Rotate(movementDirection);
            Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);


            float movementSpeed = GetMovementSpeed();

            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
            stateMachine.player.Rigidbody.AddForce(targetRotationDirection * movementSpeed-currentPlayerHorizontalVelocity,ForceMode.VelocityChange);
        }







        #endregion



        #region Reusable Methods

        protected void SetBaseRotationData()
        {
            stateMachine.ReusableData.RotationData = movementData.BaseRotationData;
            stateMachine.ReusableData.TimeToReachTargetRotation = movementData.BaseRotationData.TargetRotationReachTime;

        }


        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(stateMachine.ReusableData.MovementInput.x, 0f, stateMachine.ReusableData.MovementInput.y);
        }
        protected float GetMovementSpeed()
        {
            return movementData.BaseSpeed * stateMachine.ReusableData.MovementSpeedModifier*stateMachine.ReusableData.MovementOnSlopeSpeedModifier;
        }
        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.player.Rigidbody.velocity;
            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }

        protected Vector3 GetPlayerVerticalVelocity()
        {
            return new Vector3(0f, stateMachine.player.Rigidbody.velocity.y, 0f);
        }




        #region CameraRotation
        protected float UpdateTargetRotation(Vector3 direction,bool considerCamRotation = true)
        {
            float directionAngle = GetDirectionAngle(direction);

            if (considerCamRotation)
            {
                directionAngle = AddCameraRotationAngle(directionAngle);
            }
            

            if (directionAngle !=stateMachine.ReusableData.CurrentTargetRotation.y)
            {
                UpdateTargetRotationData(directionAngle);
            }

            return directionAngle;
        }

        private void UpdateTargetRotationData(float targetAngle)
        {
            stateMachine.ReusableData.CurrentTargetRotation.y = targetAngle;

            stateMachine.ReusableData.DampedTargetRotationPassedTime.y = 0f;
        }
        protected void RotateTowardsTargetRotation()
        {
            float currentYAngle = stateMachine.player.Rigidbody.rotation.eulerAngles.y;

            if(currentYAngle == stateMachine.ReusableData.CurrentTargetRotation.y)
            {
                return;
            }

            float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, stateMachine.ReusableData.CurrentTargetRotation.y, ref stateMachine.ReusableData.DampedTargetRotationCurrentVelocity.y, stateMachine.ReusableData.TimeToReachTargetRotation.y - stateMachine.ReusableData.DampedTargetRotationPassedTime.y);

            stateMachine.ReusableData.DampedTargetRotationPassedTime.y += Time.deltaTime;


            Quaternion targetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);

            stateMachine.player.Rigidbody.MoveRotation(targetRotation);
        }

        protected Vector3 GetTargetRotationDirection(float targetAngle)
        {
            return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }


     

        #endregion


        protected void ResetVelocity()
        {
            stateMachine.player.Rigidbody.velocity = Vector3.zero;
        }

        protected void ResetVerticalVelocity()
        {
            Vector3 playerHorizontalVelocity = GetPlayerHorizontalVelocity();
            stateMachine.player.Rigidbody.velocity = playerHorizontalVelocity;
        }

        #region MovementStateCallbacks

        protected virtual void AddInputActionsCallbacks()
        {
            stateMachine.player.input.playerActions.WalkToggle.started += OnWalkToggleStarted;
        }

   

        protected virtual void RemoveInputActionsCallbacks()
        {
            stateMachine.player.input.playerActions.WalkToggle.started -= OnWalkToggleStarted;
        }
        #endregion


        protected void DecelerateHorizontally()
        {
            //when called speedmodifier is 0 addforce wont be called in move method
            //no need to set velocity to 0 as it will transition to idle state which already sets

            Vector3 playerHorizontalVelocity = GetPlayerHorizontalVelocity();

           
            stateMachine.player.Rigidbody.AddForce(-playerHorizontalVelocity * stateMachine.ReusableData.MovementDecelerationForce, ForceMode.Acceleration);

        }

        protected void DecelerateVertically()
        {
         
            Vector3 playerVerticalVelocity = GetPlayerVerticalVelocity();


            stateMachine.player.Rigidbody.AddForce(-playerVerticalVelocity * stateMachine.ReusableData.MovementDecelerationForce, ForceMode.Acceleration);

        }
        protected bool IsMovingHorizontal(float minMagnitude = 0.1f)
        {
            Vector3 playerHorizontalVelocity = GetPlayerHorizontalVelocity();
            //remove y
            Vector2 playerHorizontalMovement = new Vector2(playerHorizontalVelocity.x, playerHorizontalVelocity.z);
            return playerHorizontalMovement.magnitude > minMagnitude;
        }
        
        protected bool IsMovingUp(float minimumVelocity = 0.1f)
        {
            return GetPlayerVerticalVelocity().y > minimumVelocity;
        }
        protected bool IsMovingDown(float minimumVelocity = 0.1f)
        {
            return GetPlayerVerticalVelocity().y < -minimumVelocity;
        }
        protected virtual void OnContactWithGround(Collider collider)
        {

        }

        protected virtual void OnContactWithGroundExited(Collider collider)
        {
            
        }

        #endregion





        //inputs callback methods
        #region Input Methods

        protected virtual void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            stateMachine.ReusableData.ToggleWalk = !stateMachine.ReusableData.ToggleWalk;
        }


        #endregion
    }
}
