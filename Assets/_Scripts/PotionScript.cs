﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats playerStats = collision.GetComponent<PlayerStats>();
        //make sure the player picks up the coins
        if (playerStats != null)
        {
            //increase the players lives by 1
            playerStats.AddLife();
        }
    }
}
