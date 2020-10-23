using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    //public BoxCollider2D deathBoxCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Entered Collider");
        //kill the player when they enter the collider
        collision.GetComponent<PlayerStats>().Death();  
    }


    
}
