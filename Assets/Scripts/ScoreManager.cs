using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    private Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }
    public void ScorePlus(int point) 
    {
        score += point;
        scoreText.text = score.ToString();
    }
    public void ScoreReset()
    {
        score = 0;
    }
}
