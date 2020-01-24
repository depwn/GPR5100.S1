using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    
    void Start()
    {
        
         PhotonNetwork.Instantiate("AirHockeyPad", new Vector3(0.0f, 1.31f, -2.20f), Quaternion.identity,0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
