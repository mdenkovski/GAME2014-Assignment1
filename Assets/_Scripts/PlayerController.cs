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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }
        //use the horizontal axis for the movememnt
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        Vector2 newVelocity = Rigidbody.velocity + new Vector2(direction * Speed * Time.deltaTime, 0.0f);
        Rigidbody.velocity = newVelocity;

        //parse movement
        if (joystick.InputDirection.x > 0.2f)//mov right
        {
            Rigidbody.velocity = new Vector2(joystick.InputDirection.x * Speed * Time.deltaTime, Rigidbody.velocity.y);
            //animator.SetBool("IsRunning", true);
        }
        else if (joystick.InputDirection.x < -0.2f) // move left
        {
            Rigidbody.velocity = new Vector2(joystick.InputDirection.x * Speed * Time.deltaTime, Rigidbody.velocity.y);
            // animator.SetBool("IsRunning", true);
            //animator.SetBool("Flipped", true);
        }
        else
        {
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
            //animator.SetBool("IsRunning", false);
        }

        if (joystick.InputDirection.y > 0.7f) //jump
        {
            if(transform.position.y <1.16) //if near gorund level
            {
                Debug.Log("Jumping");
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpPower * Time.deltaTime) ;

            }
        }
    }
}
