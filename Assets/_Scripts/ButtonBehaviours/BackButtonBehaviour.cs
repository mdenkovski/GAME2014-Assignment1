using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// BackButtonBehaviour.cs
/// Oct 3, 2020: simple load to start screen
/// </summary>

public class BackButtonBehaviour : MonoBehaviour
{
    // Event Handler for the StartButton_Pressed Event
    public void OnBackButtonPressed()
    {
        Debug.Log("BackButton Pressed");
        SceneManager.LoadScene("Start");
    }
}
