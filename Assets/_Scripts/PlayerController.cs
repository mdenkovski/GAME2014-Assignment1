using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D Rigidbody;
    public float Speed = 5;
    public float JumpPower  = 5;

    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private float direction = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //parse movement
        if (joystick.InputDirection.x > 0.2f)//move right
        {
            //Debug.Log("Moving Right");
            Rigidbody.velocity = new Vector2(Speed , Rigidbody.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (joystick.InputDirection.x < -0.2f) // move left
        {
            spriteRenderer.flipX = true;
            //Debug.Log("Moving Left");
            Rigidbody.velocity = new Vector2(-Speed , Rigidbody.velocity.y);
        }
        else //dont move left or right
        {
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        animator.SetFloat("Speed", math.abs(Rigidbody.velocity.x));

        if (joystick.InputDirection.y > 0.8f) //jump
        {
            if (transform.position.y < 1.16 && transform.position.y > 1.15) //if near gorund level
            {
                //Debug.Log("Jumping");
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpPower);
                animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Debug.DrawLine(transform.position, transform.position +  new Vector3(joystick.InputDirection.normalized.x, joystick.InputDirection.normalized.y, 0.0f)*5);

    }

    
}
