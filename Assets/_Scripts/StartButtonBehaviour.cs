using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
   

    // Event Handler for the StartButton_Pressed Event
    public void OnStartButtonPressed()
    {
        Debug.Log("StartButton Pressed");
        SceneManager.LoadScene("Play");
    }
}
