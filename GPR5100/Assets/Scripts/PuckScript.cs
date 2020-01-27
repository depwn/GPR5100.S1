using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuckScript : MonoBehaviourPunCallbacks
{
    public ScoreScript Score;
    private bool goal ;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        goal = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (!goal)
       {
            Debug.Log("problem1");
            if (other.tag == "TopGoal")
            {
                Debug.Log("problem2");
                other.gameObject.GetComponent<PhotonView>().RPC("IncreaseScore",RpcTarget.AllBuffered,ScoreScript.Score.FirstPlayerScore);
               
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
                
            }
            else if (other.tag == "BottomGoal")
            {
                Debug.Log("problem3");
                other.gameObject.GetComponent<PhotonView>().RPC("IncreaseScore", RpcTarget.AllBuffered,ScoreScript.Score.SecondPlayerScore);
               
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
                
            }
       }
    }
    
 
}
