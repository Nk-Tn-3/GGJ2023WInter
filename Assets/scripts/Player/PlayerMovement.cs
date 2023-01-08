using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    
    private Player player;
    private Rigidbody rbody;
    private Vector2 direction; //the direction the player input is moving in
    [field: SerializeField] private float speed = 4; //the current movement speed of the player (in the future can be altered by aceleration)

    [field: SerializeField]
    Vector3 rotation;

    [field: SerializeField] float RotationTime = 0.02f, deceleration =5f;
    Vector3 dampedTime;
    public PlayerMovement(Player player)
    {
        this.player = player;
    }
   public void Initialize()
    {
        rbody = player.Rigidbody;
  
    }

    public void CallFixedUpdate()

    {
        ReadMovementInput();
        Move();
    }
    private void ReadMovementInput()
    {
        direction = player.input.GetMovement();
    }
    private void Move()
    {
        float movementSpeed = player.GetPlayeSpeed();
        if (direction == Vector2.zero || movementSpeed == 0)
        {
            DecelerateHorizontally();
            return;
        }

        Vector3 movementDirection = new Vector3(direction.x, 0f, direction.y);

        float targetRotationYAngle = Rotate(movementDirection);
        Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);


       
       
        Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
      
       rbody.AddForce(targetRotationDirection * movementSpeed - currentPlayerHorizontalVelocity, ForceMode.VelocityChange);
    }

    private float Rotate(Vector3 direction)
    {
        float directionAngle = UpdateTargetRotation(direction);
        RotateTowardsTargetRotation();

        return directionAngle;
    }


    protected void RotateTowardsTargetRotation()
    {
        float currentYAngle = rbody.rotation.eulerAngles.y;

        if (currentYAngle == direction.y)
        {
            return;
        }

        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, rotation.y, ref rotation.y, RotationTime-dampedTime.y);

        dampedTime.y += Time.deltaTime;


        Quaternion targetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);

     rbody.MoveRotation(targetRotation);
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
    protected Vector3 GetTargetRotationDirection(float targetAngle)
    {
        return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }
    private void UpdateTargetRotationData(float targetAngle)
    {
        rotation.y = targetAngle;
        dampedTime.y = 0;
       
    }
    protected Vector3 GetPlayerHorizontalVelocity()
    {
        Vector3 playerHorizontalVelocity =rbody.velocity;
        playerHorizontalVelocity.y = 0f;
        return playerHorizontalVelocity;
    }

    protected float UpdateTargetRotation(Vector3 direction)
    {
        float directionAngle = GetDirectionAngle(direction);

      


        if (directionAngle != rotation.y)
        {
            UpdateTargetRotationData(directionAngle);
        }

        return directionAngle;
    }

    protected void DecelerateHorizontally()
    {
        //when called speedmodifier is 0 addforce wont be called in move method
        //no need to set velocity to 0 as it will transition to idle state which already sets

        Vector3 playerHorizontalVelocity = GetPlayerHorizontalVelocity();


        rbody.AddForce(-playerHorizontalVelocity * deceleration, ForceMode.Acceleration);

    }
}
