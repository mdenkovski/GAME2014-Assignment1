using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// EnemyStats.cs
/// Last Edit Oct 21, 2020
/// - added stats that an enemy would need
/// - added take damage and death functions to control those functions
/// </summary>
public class EnemyStats : MonoBehaviour
{
    //parameters for control
    public GroundEnemyController Controller;
    public BoxCollider2D Collider;
    public Animator animator;

    //for updating the score
    public int scoreValue = 10;
    private GameController gameController;

    //set our max health in editor
    public float maxHealth;
    //health is initialized to max health on start
    private float health;

    public float AttackPower = 10;
    public float AttackSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //set health to max health
        health = maxHealth;
        gameController = FindObjectOfType<GameController>();
    }

    /// <summary>
    /// call whenever we take damage of x amount
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        health -= damage;

        animator.SetTrigger("Hit");

        if(health <= 0)
        {
            _Death();
        }
    }

    /// <summary>
    /// when we die deactivate all active components
    /// </summary>
    private void _Death()
    {
        Debug.Log("Dead");
        animator.SetBool("IsDead",true);
        gameController.IncreaseScore(scoreValue);
        Controller.Rigidbody.gravityScale = 0;
        Controller.Rigidbody.velocity = new Vector3();
        Controller.enabled = false;
        Collider.enabled = false;
        this.enabled = false;
    }

    
}
