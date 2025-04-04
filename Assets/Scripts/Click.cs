using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        UpdateScoreText();
    }

    public void OnClickButton()
    {
        score++;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
