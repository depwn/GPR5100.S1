using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //TextMeshProUGUI playerNameText,player2NameText;


    void Start()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("AirHockeyPad", new Vector3(0.0f, 1.31f, -2.20f), Quaternion.Euler(-90, 0, 0), 0);
            PhotonNetwork.Instantiate("Puck", new Vector3(0.0f, 1.25f, 0f), Quaternion.identity, 0);
            //playerNameText.text = photonView.Owner.NickName;
        }
        else
        {
            PhotonNetwork.Instantiate("AirHockeyPad2", new Vector3(0.0f, 1.31f, 2.20f), Quaternion.Euler(-90, 0, 0), 0);
            //player2NameText.text = photonView.Owner.NickName;
        }

        

    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Puck")!=true)
        {
            StartCoroutine(ResetPosition());
            //PhotonNetwork.Instantiate("Puck", new Vector3(0.0f, 1.25f, 0f), Quaternion.identity, 0);
        }
    }
    [PunRPC]
    public  IEnumerator ResetPosition()
    {
        yield return new WaitForSecondsRealtime(1);
        //goal = false;
        if ((GameObject.FindGameObjectWithTag("Puck") != true) && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Puck", new Vector3(0.0f, 1.25f, 0f), Quaternion.identity, 0);
        }
            
        
        //rb.velocity = rb.position = new Vector3(0f, 1.25f, 0f);
    }

    /*void SetPlayerUI()
    {
        if (playerNameText != null)
        {
          playerNameText.text = photonView.Owner.NickName;
        }
       
    }*/
}
