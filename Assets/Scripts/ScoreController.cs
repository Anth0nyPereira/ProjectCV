using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int currentScore = 0;

    // Update is called once per frame
    //void Update()
    //{
    //   scoreText.text = "Score:" + currentScore.ToString();     
    //}

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score:" + currentScore.ToString();
    }
}
