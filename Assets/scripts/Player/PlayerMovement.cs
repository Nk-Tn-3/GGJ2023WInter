using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float test_speed/*, max_speed, acceleration, deaceleration, gravity_max*//*, gravity acceleration*/;
    private Rigidbody rbody;
    private Vector3 direction; //the direction the player input is moving in
    private float cur_speed; //the current movement speed of the player (in the future can be altered by aceleration)

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        cur_speed = test_speed;
    }

    private void FixedUpdate()
    {
        //in use - - - -

        Vector3 dest = direction * cur_speed * Time.fixedDeltaTime;
        rbody.position += dest;
        //need something to rotate player to move direction (like teh LookAt function)

        //animation

        //prototyping / future use - - - - -

        /*//acceleration
        if(direction != Vector2.zero)
        {
            speed += acceleration;
            if (cur_speed > max_speed)
                cur_speed = max_speed;
        } */

        //gravity?
    }

    public void UpdateDirection(Vector2 input)
    {
        direction.x = input.x;
        direction.z = input.y;
    }
}
