using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// PlayerStats.cs
/// Last Edit Oct 21, 2020
/// - added stats that the player would need
/// - added functions for taking damage and death
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
        health -= damage;

        if (health <= 0)
        {
            _Death();
        }
    }

    /// <summary>
    /// call when the player dies. deactivate control of the player
    /// </summary>
    private void _Death()
    {
        Debug.Log("Dead");
        animator.SetBool("IsDead", true);
        Controller.enabled = false;
        this.enabled = false;
    }
}
