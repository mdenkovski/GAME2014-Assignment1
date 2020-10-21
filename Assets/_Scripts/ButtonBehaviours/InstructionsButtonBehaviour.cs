using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// InstructionsButtonBehaviour.cs
/// Oct 3, 2020: simple load to instructions screen
/// </summary>

public class InstructionsButtonBehaviour : MonoBehaviour
{
    public void OnInstructionsButtonPressed()
    {
        Debug.Log("Instructions Button Pressed");
        SceneManager.LoadScene("Instructions");
    }
}
