using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure the player enters the treasure
        if (collision.GetComponent<PlayerStats>() != null)
        {
            FindObjectOfType<GameController>().SetGameWonStatus(false);
            //transition to the end scene
            SceneManager.LoadScene("End");

        }
    }
}
