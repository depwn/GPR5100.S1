using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Movement : MonoBehaviourPunCallbacks
{
   
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private GameObject topBorder;
    [SerializeField] private GameObject bottomBorder;
    [SerializeField] private GameObject bottomBorder1;

    Rigidbody rb;

    static public List<string> names = new List<string>();

    [SerializeField]
    TextMeshProUGUI playerNameText;

    [SerializeField]
    private float thrust=100000f;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            leftBorder = GameObject.Find("LeftBorder");
            rightBorder = GameObject.Find("RightBorder");
            bottomBorder = GameObject.Find("BottomBorder");
            topBorder = GameObject.Find("TopBorder");
        }
        else
        {
            leftBorder = GameObject.Find("LeftBorder");
            rightBorder = GameObject.Find("RightBorder");
            bottomBorder1 = GameObject.Find("BottomBorder1");
            topBorder = GameObject.Find("TopBorder");
        }
       
        rb = GetComponent<Rigidbody>();
        SetPlayerUI();
    }

  
    void FixedUpdate()
    {
        PlayerMove();
        //rb.AddForce(transform.forward * thrust);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }
        }

        

    }

    private void PlayerMove()
    {
        if (PhotonNetwork.IsConnected && photonView.IsMine)
        {

            transform.GetComponent<Movement>().enabled = true;
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                //if (raycastHit.collider.gameObject.GetPhotonView().IsMine)
                //{
                    transform.position = raycastHit.point;
                if(PhotonNetwork.IsMasterClient)
                {
                    float clampedX = Mathf.Clamp(transform.position.x, leftBorder.transform.position.x, rightBorder.transform.position.x);
                    float clampedZ = Mathf.Clamp(transform.position.z, bottomBorder.transform.position.z, topBorder.transform.position.z);
                    transform.position = new Vector3(clampedX, 1.31f, clampedZ);

                }
                else
                {
                    float clampedX = Mathf.Clamp(transform.position.x, leftBorder.transform.position.x, rightBorder.transform.position.x);
                    float clampedZ = Mathf.Clamp(transform.position.z,topBorder.transform.position.z, bottomBorder1.transform.position.z);
                    transform.position = new Vector3(clampedX, 1.31f, clampedZ);
                }
                    
                //}
     
            }
        }
        else
        {
            transform.GetComponent<Movement>().enabled = false;

        }


    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Puck"))
        {
            Debug.Log(col.collider.name);
            ApplyForce(col.rigidbody);
        }
        
    }
    
    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = (body.transform.position - transform.position)*thrust;
        body.AddForceAtPosition(direction.normalized, transform.position,ForceMode.Impulse);
        
    }

    void SetPlayerUI()
    {
        if (playerNameText != null)
        {
          playerNameText.text = photonView.Owner.NickName;
            names.Add(playerNameText.text);
        }
       
    }
}

