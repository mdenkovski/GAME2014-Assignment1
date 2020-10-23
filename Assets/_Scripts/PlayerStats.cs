using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// PlayerStats.cs
/// Last Edit Oct 23, 2020
/// - added stats that the player would need
/// - added functions for taking damage and death
/// - added coroutine to taking damage so that timing works better
/// - added transition to game over screen
/// </summary>

public class PlayerStats : MonoBehaviour
{
    //components for control
    public PlayerController Controller;
    public Animator animator;

    //set our max health in editor
    public float maxHealth;
    //health is initialized to max health on start
    private float health;
    //keep track if we are dead
    private bool b_dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //set health to max health
        health = maxHealth;
    }

    /// <summary>
    /// Call when the player takes damage based on x damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (!b_dead)
        {
            StartCoroutine(Hit(damage));
        }
    }

    /// <summary>
    /// Coroutine function to have a delay before aplying damage to allow for animations to occur
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    IEnumerator Hit(float damage)
    {
        yield return new WaitForSeconds(0.5f);
        if (!b_dead)
        {
            animator.SetTrigger("Hit");
            health -= damage;
        }
        if (health <= 0)
        {
            health = 0;
            
            Death();
        }
    }
    /// <summary>
    /// coroutine to transition to game over screen after 3 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator TransitionToGameOver()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Loading End Scene");
        SceneManager.LoadScene("End");
    }


    /// <summary>
    /// call when the player dies. deactivate control of the player
    /// </summary>
    public void Death()
    {
        Debug.Log("Dead");
        b_dead = true;
        StartCoroutine(TransitionToGameOver());
        Controller.Rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        animator.SetBool("IsDead", true);
        if(health >0)
        {
            animator.SetTrigger("EnvirontmentDeath");
        }
        Controller.enabled = false;
        //this.enabled = false;
    }
}
