using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// PlayerController.cs
/// Last Edit Oct 21, 2020
/// - added movement to take input from our joystick
/// - added animation transitions based on actions
/// - added player attack
/// </summary>

public class PlayerController : MonoBehaviour
{
    //the joystick we use to control the player
    public Joystick joystick;
    //our body that we are moving
    public Rigidbody2D Rigidbody;
    //how fast we move
    public float Speed = 5;
    //how strong we jump
    public float JumpPower  = 5;

    //use to control our animations
    public Animator animator;
    //use to manipulate the direction of our sprite
    private SpriteRenderer spriteRenderer;

    //all our variables we need to control our attacks
    [Header("Attacking")]
    public Transform AttackPositoin;
    public float AttackRange = 0.2f; // how far from the attack position we can reach
    public LayerMask enemyLayers; // know where to find our enemies
    public float AttackPower = 10; //how much damage we deal
    public float AttackSpeed = 1.0f; // how many seconds need to pass for us to attack
    private float lastAttack;


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
            //flip our sprite to face the opposite direction
            spriteRenderer.flipX = true;
            //Debug.Log("Moving Left");
            Rigidbody.velocity = new Vector2(-Speed , Rigidbody.velocity.y);
        }
        else //dont move left or right
        {
            //dont want to move left or right here
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        animator.SetFloat("Speed", math.abs(Rigidbody.velocity.x));

        if (joystick.InputDirection.y > 0.8f) //jump
        {
            if (transform.position.y < 1.16 && transform.position.y > 1.15) //if near gorund level
            {
                //Debug.Log("Jumping");
                //preserve our x velocit while jumping
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpPower);
                animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            //not jumping
            animator.SetBool("IsJumping", false);
        }

        //Debug.DrawLine(transform.position, transform.position +  new Vector3(joystick.InputDirection.normalized.x, joystick.InputDirection.normalized.y, 0.0f)*5);

        Debug.DrawLine(AttackPositoin.position, AttackPositoin.position + Vector3.right * AttackRange, Color.red);
    }

    /// <summary>
    /// Call when we press the attack button to perform our attack
    /// </summary>
    public void Attack()
    {
        //check if the difference from the last time we attacked is greater than our attack speed in seconds
        if (Time.time - lastAttack > AttackSpeed)
        {
            //Debug.Log("Attacking");
            animator.SetTrigger("Attack"); //attack animation
            //get all the enemies hit in the circle and that are on the layer
            //Collider2D hitEnemy = Physics2D.OverlapCircle(AttackPositoin.position, AttackRange, enemyLayers);
            
            RaycastHit2D hit = Physics2D.Linecast(AttackPositoin.position, AttackPositoin.position + Vector3.right * AttackRange, enemyLayers);
            Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                hit.collider.GetComponent<EnemyStats>().TakeDamage(AttackPower);
            }
            //perform damage calculation if we hit the enemy
            //hitEnemy.GetComponent<EnemyStats>().TakeDamage(AttackPower);
            //set our last attack time to the current time
            lastAttack = Time.time;
        }

    }
}
