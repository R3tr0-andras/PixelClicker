using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public int score = 0;

    public void OnClickButton()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
