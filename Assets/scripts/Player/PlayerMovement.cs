using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float test_speed, max_speed, acceleration, deaceleration, gravity_max/*, gravity acceleration*/;
    private Rigidbody rbody;
    private Vector3 direction, last_direction;
    private float cur_speed;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        cur_speed = test_speed;
    }

    private void Update()
    {
        /*//acceleration
        if(direction != Vector2.zero)
        {
            speed += acceleration;
            if (cur_speed > max_speed)
                cur_speed = max_speed;
        } */
        //move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       /* h = 0;
        v = 0;
        if (Input.GetKey(KeyCode.A))
            h = -1;
        if (Input.GetKey(KeyCode.D) && h == 0)
            h = 1;
        if (Input.GetKey(KeyCode.W))
            v = 1;
        if (Input.GetKey(KeyCode.S) && v == 0)
            v = -1;*/

        //direction = new Vector2(h, v);
        Vector3 dest = direction * cur_speed * Time.deltaTime;
        //rbody.MovePosition(dest);
        rbody.position += dest;

        //gravity?

        
        //anim
    }

    public void UpdateDirection(Vector2 input)
    {
        direction.x = input.x;
        direction.z = input.y;
    }
}
