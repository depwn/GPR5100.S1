using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenuController : MonoBehaviour {

	public void PlayGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
