using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Michael Dnekovski 101222288 Game 2014
/// GameController.cs
/// Oct 3, 2020: updated rotation to account for landsape ref resolution
/// </summary>

public class GameController : MonoBehaviour
{
    //public TMP_Text SceneLabel;
    public TMP_Text LivesLabel;
    public TMP_Text ScoreLabel;

    public CanvasScaler scaler;

    private float livesLabelHalfWidth;
    private float livesLabelHalfHeight;
    private float scoreLabelHalfWidth;
    private float scoreLabelHalfHeight;

   public Vector2 scale;

    private void Start()
    {
        Vector2 ScreenRes = new Vector2(Screen.safeArea.width, Screen.safeArea.height);
        Vector2 RefRes = scaler.referenceResolution;
        //correct orientation of ref res based on orientation of screen
        if (Screen.orientation == ScreenOrientation.Landscape)
        {
            float tempX = RefRes.x;
            RefRes.x = RefRes.y;
            RefRes.y = tempX;

        }
        scale = ScreenRes / RefRes;

        livesLabelHalfWidth = scale.x * LivesLabel.rectTransform.rect.width * 0.5f;
        livesLabelHalfHeight = scale.y * LivesLabel.rectTransform.rect.height * 0.5f;
        scoreLabelHalfWidth = scale.x * ScoreLabel.rectTransform.rect.width * 0.5f;
        scoreLabelHalfHeight = scale.y * ScoreLabel.rectTransform.rect.height * 0.5f;

        
        //debug the position adjustment values
        Rect safeArea = Screen.safeArea;
        //Debug.Log("X: " + safeArea.width);
        //Debug.Log("Y: " + safeArea.height);
        //Debug.Log("width: " + Screen.width);
        //Debug.Log("height: " + Screen.height);
      
        //Debug.Log("safe area left: " + Screen.safeArea.xMin);
        //Debug.Log("safe area right: " + Screen.safeArea.xMax);

        //Debug.Log("half width: " + livesLabelHalfWidth);
        //Debug.Log("half height: " + livesLabelHalfHeight);
        //Debug.Log("Scaler ref:  " + scaler.referenceResolution);
        //Debug.Log("Scaler multiplier:  " + scale);
    }


    // Update is called once per frame
    void Update()
    {

        LivesLabel.rectTransform.position = new Vector2(Screen.safeArea.xMin + livesLabelHalfWidth, Screen.safeArea.yMax - livesLabelHalfHeight);
        ScoreLabel.rectTransform.position = new Vector2(Screen.safeArea.xMax - scoreLabelHalfWidth, Screen.safeArea.yMax - scoreLabelHalfHeight);

       
    }
}
