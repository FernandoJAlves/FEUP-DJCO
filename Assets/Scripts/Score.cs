using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int score = 0;
    private string scoreLabel = "SCORE: ";
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        score = GameStateController.instance.score;
        scoreText.text = this.scoreLabel + score.ToString("000");
    }
}
