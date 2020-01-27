using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuckScript : MonoBehaviour
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
                //Score.IncreaseScore(ScoreScript.Score.FirstPlayerScore);
                goal = true;
                StartCoroutine(ResetPosition());
                PhotonNetwork.Destroy(this.gameObject);
            }
            else if (other.tag == "BottomGoal")
            {
                Debug.Log("problem3");
                other.gameObject.GetComponent<PhotonView>().RPC("IncreaseScore", RpcTarget.AllBuffered,ScoreScript.Score.SecondPlayerScore);
                this.gameObject.GetComponent<PhotonView>().RPC("ResetPosition",RpcTarget.AllBuffered);
                //Score.IncreaseScore(ScoreScript.Score.SecondPlayerScore);
                goal = true;
                StartCoroutine(ResetPosition());
                PhotonNetwork.Destroy(this.gameObject);
            }
       }
    }
    
    private IEnumerator ResetPosition()
    {
        yield return new WaitForSecondsRealtime(1);
        goal = false;
        PhotonNetwork.Instantiate("Puck", new Vector3(0.0f, 1.25f, 0f), Quaternion.identity, 0);
        
        
        //rb.velocity = rb.position = new Vector3(0f, 1.25f, 0f);
    }
}
