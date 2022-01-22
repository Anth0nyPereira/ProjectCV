using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int i = 0;

    // Update is called once per frame
    void Update()
    {
       scoreText.text = "Score:" + i.ToString();     
    }
}
