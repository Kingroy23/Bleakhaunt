using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement_scalar;
    public float jump_scalar;
    public float max_speed;
    private Rigidbody2D rb;
    private bool is_on_ground;
    public Transform t1;
    public Animator animator;

    




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

            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));

            if (movement.x < 0.0f)
            {
                t1.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (movement.x >= 0.0f)
            {
                t1.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (Input.GetButtonDown("Jump") && is_on_ground)
        {
            Vector2 jump_force = new Vector2(0, jump_scalar);
            rb.AddForce(jump_force);
            animator.SetBool("IsJumping", true);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = true;
            animator.SetBool("IsJumping", false);
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
