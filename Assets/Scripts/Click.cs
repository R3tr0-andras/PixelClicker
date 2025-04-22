using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    public float score = 0;
    public TextMeshProUGUI scoreText;
    public int increment = 1;

    void Start()
    {
        UpdateScoreText();
    }

    public void OnClickButton()
    {
        AddClickCount(increment);
    }

    public void AddClickCount(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void AddScore(float amount)
    {
        score += Mathf.RoundToInt(amount);
        UpdateScoreText();
    }

    public void RemoveScore(float amount)
    {
        score -= Mathf.RoundToInt(amount);
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    public float GetScore()
    {
        return score;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }
    public void AddClickPower(float amount)
    {
        increment += Mathf.RoundToInt(amount);
    }

}
