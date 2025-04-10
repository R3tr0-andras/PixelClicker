using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int increment = 1;

    public void Start()
    {
        UpdateScoreText();
    }

    public void OnClickButton()
    {
        AddClickCount(increment);
        
    }

    public void AddClickCount(int increment)
    {
        score += increment;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
