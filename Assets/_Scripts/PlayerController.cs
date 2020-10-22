using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D Rigidbody;
    public float Speed = 5;
    public float JumpPower  = 5;

    public Animator animator;


    private float direction = 0;

    

    // Update is called once per frame
    void Update()
    {
        //parse movement
        if (joystick.InputDirection.x > 0.2f)//move right
        {
            Debug.Log("Moving Right");
            Rigidbody.velocity = new Vector2(Speed , Rigidbody.velocity.y);
            //animator.SetBool("IsRunning", true);
        }
        else if (joystick.InputDirection.x < -0.2f) // move left
        {
            Debug.Log("Moving Left");
            Rigidbody.velocity = new Vector2(-Speed , Rigidbody.velocity.y);
            // animator.SetBool("IsRunning", true);
            //animator.SetBool("Flipped", true);
        }
        else //dont move left or right
        {
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
            //animator.SetBool("IsRunning", false);
        }

        if (joystick.InputDirection.y > 0.8f) //jump
        {
            if (transform.position.y < 1.16) //if near gorund level
            {
                Debug.Log("Jumping");
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.y + JumpPower);

            }
        }

        Debug.DrawLine(transform.position, transform.position +  new Vector3(joystick.InputDirection.normalized.x, joystick.InputDirection.normalized.y, 0.0f)*5);

    }

    
}
