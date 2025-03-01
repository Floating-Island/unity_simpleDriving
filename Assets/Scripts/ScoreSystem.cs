using System;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreGain = 1f;

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

    private void DisplayScore()
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void IncreaseScore()
    {
        score += (float)scoreGain * Time.deltaTime;
    }
}
