using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ScoreScript : MonoBehaviourPunCallbacks
{
    [Header("Win UI Panel")]
    public GameObject Win_UI_Panel;
    
    private string playerNameText;
    public GameObject WIN_UI_NameText;
    
    bool isActive = false;
    

    public enum Score
    {
        FirstPlayerScore,SecondPlayerScore
    }

    [SerializeField]
    private Text Player1ScoreText, Player2ScoreText;

    
    private int player1score, player2score;

    public void Start()
    {
        //Win_UI_Panel = GameObject.Find("WinCanvas").transform.Find("WinPanel").gameObject;
        //Win_UI_Panel = GameObject.Find("WinCanvas").transform.GetComponentInChildren
        //Win_UI_Panel = GameObject.Find("WinCanvas");
        //Win_UI_Panel.SetActive(false);
        player1score = 0;
        player2score = 0;
    }


    [PunRPC]
    public void IncreaseScore(Score score)
    {
        if(score == Score.FirstPlayerScore)
        {
            Player1ScoreText.text = (++player1score).ToString();
            if (player1score >= 5)
            {
                PhotonNetwork.DestroyAll();
                playerNameText = Movement.names[0];
                Debug.Log(playerNameText + " won");
                /*if (!isActive)
                {
                    ActivatePanel(Win_UI_Panel.name);
                }*/
                isActive = true;
                leaveroom();
            }
        }
        else
        {
            Player2ScoreText.text = (++player2score).ToString();
            if (player2score >= 5)
            {

                PhotonNetwork.DestroyAll();
                playerNameText = Movement.names[1];
                Debug.Log(playerNameText+ " won");
                isActive = true;
                /*if (!isActive)
                {
                    ActivatePanel(Win_UI_Panel.name);

                }*/
                leaveroom();
            }
        }
    }

    private void Update()
    {
        if (isActive)
        {
            ActivatePanel(Win_UI_Panel.name);
            //Win_UI_Panel.SetActive(true);
        }
    }

    public void ActivatePanel(string panelToBeActivated)
    {
        Win_UI_Panel.SetActive(panelToBeActivated.Equals(Win_UI_Panel.name));
    }

    [PunRPC]
    public void leaveroom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel(0);
    }
}
