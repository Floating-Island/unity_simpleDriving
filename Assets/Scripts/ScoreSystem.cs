using System;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreGain = 1f;

    public const string highScoreKey = "Key_HighScore";

    private float score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore();
        DisplayScore();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        int gameScore = GetScore();
        if (gameScore > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, gameScore);
        }
    }

    private void DisplayScore()
    {
        scoreText.text = GetScore().ToString();
    }

    private int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    private void IncreaseScore()
    {
        score += (float)scoreGain * Time.deltaTime;
    }
}
