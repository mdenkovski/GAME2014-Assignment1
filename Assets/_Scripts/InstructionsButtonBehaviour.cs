using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonBehaviour : MonoBehaviour
{
    public void OnInstructionsButtonPressed()
    {
        Debug.Log("Instructions Button Pressed");
        SceneManager.LoadScene("Instructions");
    }
}
