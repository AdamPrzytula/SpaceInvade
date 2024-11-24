using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt, hiScoreTxt;
    public float scoreCount, hiScoreCount;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("Score");
        }

    }

    void Update()
    {
        scoreTxt.text = "SCORE: " + MathF.Round(scoreCount);
        hiScoreTxt.text = "SCORE: " + MathF.Round(hiScoreCount);

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        PlayerPrefs.SetFloat("Score", scoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
