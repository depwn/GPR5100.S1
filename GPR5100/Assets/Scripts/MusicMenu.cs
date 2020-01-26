using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMenu : MonoBehaviour
{
    public GameObject MusicPanel;

    bool isActive;

    public void onMusicButtonClicked()
    {
        if (isActive)
        {
            MusicPanel.SetActive(true);
            isActive = false;
        }
        else
        {
            MusicPanel.SetActive(false);
            isActive = true;
        }
        

    }
}
