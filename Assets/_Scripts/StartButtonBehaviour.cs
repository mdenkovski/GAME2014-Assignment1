using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// StartButtonBehaviour.cs
/// Oct 3, 2020: simple load to play scene
/// </summary>

public class StartButtonBehaviour : MonoBehaviour
{
   

    // Event Handler for the StartButton_Pressed Event
    public void OnStartButtonPressed()
    {
        Debug.Log("StartButton Pressed");
        SceneManager.LoadScene("Play");
    }
}
