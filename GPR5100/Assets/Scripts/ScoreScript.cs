using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        FirstPlayerScore,SecondPlayerScore
    }

    [SerializeField]
    private Text Player1ScoreText, Player2ScoreText;

    [SerializeField]
    private int player1score, player2score;

    public void IncreaseScore(Score score)
    {
        if(score == Score.FirstPlayerScore)
        {
            Player1ScoreText.text = (++player1score).ToString();
        }
        else
        {
            Player2ScoreText.text = (++player2score).ToString();
        }
    }
}
