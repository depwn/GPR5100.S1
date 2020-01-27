using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ScoreScript : MonoBehaviourPunCallbacks
{
    [Header("Win UI Panel")]
    public string playerNameText;
    public GameObject Win_UI_Panel;
    public enum Score
    {
        FirstPlayerScore,SecondPlayerScore
    }

    [SerializeField]
    private Text Player1ScoreText, Player2ScoreText;

    
    private int player1score, player2score;

    public void Start()
    {
        player1score = 0;
        player2score = 0;
    }


    [PunRPC]
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

    private void Update()
    {
        if(player1score>=20){
            PhotonNetwork.DestroyAll();
            playerNameText = Movement.names[0];
            //Win_UI_Panel= GetComponentInChildren.text
            winnerwinnerchickendinner();
        }
        else if (player2score >= 20)
        {
            PhotonNetwork.DestroyAll();
            playerNameText = Movement.names[1];
            winnerwinnerchickendinner();
        }
    }

    public void winnerwinnerchickendinner()
    {
        
        Win_UI_Panel.SetActive(true);
    }
}
