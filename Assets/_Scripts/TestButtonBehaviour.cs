using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestButtonBehaviour : MonoBehaviour
{

    public TMP_Text LivesLabel;
    public TMP_Text ScoreLabel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event Handler for the TestButton_Pressed Event
    public void OnTestButtonPressed()
    {
        Debug.Log("testButton Pressed");
        LivesLabel.rectTransform.anchoredPosition = new Vector2(370.0f, -83.0f);
        ScoreLabel.rectTransform.anchoredPosition = new Vector2(-353.0f, -83.0f);
    }
}
