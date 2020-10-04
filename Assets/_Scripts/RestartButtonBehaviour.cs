using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// RestartButtonBehaviour.cs
/// Oct 3, 2020: simple load to play screen
/// </summary>

public class RestartButtonBehaviour : MonoBehaviour
{
    // Event Handler for the StartButton_Pressed Event
    public void OnRestartButtonPressed()
    {
        Debug.Log("RestartButton Pressed");
        SceneManager.LoadScene("Play");
    }
}
