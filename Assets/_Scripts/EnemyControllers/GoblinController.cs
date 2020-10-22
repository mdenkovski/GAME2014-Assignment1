using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// GoblinController.cs
/// Last Edit Oct 21, 2020
/// - added simple AI to move towards player if within certain range
/// - animations based on actions
/// - attack the player and deal damage if within a certain range
/// </summary>

public class GoblinController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5;
    public GameObject playerCharacter;
    public float DetectionRange = 10.0f;

    public float AttackPower = 10;
    public float AttackSpeed = 1.0f;
    private float lastAttack;



    // Start is called before the first frame update
    void Start()
    {
        //find the player so we can detect their proximity later
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //find the distance to the player
        float distance = math.distance(playerCharacter.transform.position.x, transform.position.x);

        //check distance to player if within certain amount
        if (distance < DetectionRange && distance > 1)
        {
            //Debug.Log("InRange");
            //find the direction the player is relative to us
            float direction = playerCharacter.transform.position.x - transform.position.x;
            //clamp relative direction to be within 1
            math.clamp(direction, -1, 1);
            //move based on our clamped distance and speed to the player
            transform.position += (new Vector3(direction * speed * Time.deltaTime, 0.0f, 0.0f));
            //tell animator we are running
            animator.SetFloat("Speed", math.abs(direction));

        }
        else if(distance < 1)
        {
            animator.SetFloat("Speed", 0);
            //if we are close enough to the player we can attack
            Attack();
        }
        else
        {
            //to far away so just idle
            animator.SetFloat("Speed", 0);
        }
    }

    /// <summary>
    /// Perform our attack when called
    /// </summary>
    void Attack()
    {
        //check if the difference from the last time we attacked is greater than our attack speed in seconds
        if (Time.time - lastAttack > AttackSpeed)
        {
            Debug.Log("Attacking");
            //attack animation
            animator.SetTrigger("Attack");
            //set our last attack time to the current time
            lastAttack = Time.time;
            //deal guaranteed damage to our player
            playerCharacter.GetComponent<PlayerStats>().TakeDamage(AttackPower);
        }

    }
}
