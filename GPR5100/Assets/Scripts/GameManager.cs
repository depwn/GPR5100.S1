using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("AirHockeyPad", new Vector3(0.0f, 1.31f, -2.20f), Quaternion.Euler(-90, 0, 0), 0);
            PhotonNetwork.Instantiate("Puck", new Vector3(0.0f, 1.25f, 0f), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("AirHockeyPad2", new Vector3(0.0f, 1.31f, 2.20f), Quaternion.Euler(-90, 0, 0), 0);
        }
         
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
