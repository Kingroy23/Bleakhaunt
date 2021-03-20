﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement_scalar;
    public float jump_scalar;
    public float max_speed;
    private Rigidbody2D rb;
    private bool is_on_ground;

    




    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void  Update()
    {
        float x_movement = Input.GetAxis("Horizontal");

        if(rb.velocity.magnitude < max_speed)
        {
            Vector2 movement = new Vector2(x_movement, 0);
            rb.AddForce(movement_scalar * movement);
        }

        if (Input.GetButtonDown("Jump") && is_on_ground)
        {
            Vector2 jump_force = new Vector2(0, jump_scalar);
            rb.AddForce(jump_force);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!CollisionIsWithGround(collision))
        {
            is_on_ground = false;
        }
    }

    private bool CollisionIsWithGround(Collision2D collision)
    {
        bool is_with_ground = false;
        foreach(ContactPoint2D c in collision.contacts)
        {
            Vector2 collision_direction_vector = c.point - rb.position;
            if(collision_direction_vector.y < 0)
            {
                is_with_ground = true;
            }
        }

        return is_with_ground;
    }
}