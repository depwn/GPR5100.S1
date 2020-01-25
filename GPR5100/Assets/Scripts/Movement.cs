using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPunCallbacks
{
   
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private GameObject topBorder;
    [SerializeField] private GameObject bottomBorder;
    [SerializeField] private GameObject bottomBorder1;

    Rigidbody rb;
    //[SerializeField]
    //Rigidbody rb2;

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
        //rb2 = GetComponent<Rigidbody>();
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

    [PunRPC]
    private void OnCollisionStay(Collision col)
    {
        if(col.collider.name == "Puck")
        {
            Debug.Log(col.collider.name);
            //rb.AddForce(Vector3.forward, ForceMode.Impulse);
            //rb.AddForce(transform.forward * thrust,ForceMode.Impulse);
            ApplyForce(col.rigidbody);
        }
        
    }
    [PunRPC]
    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = (body.transform.position - transform.position)*thrust;
        body.AddForceAtPosition(direction.normalized, transform.position,ForceMode.Impulse);
        
    }
}

