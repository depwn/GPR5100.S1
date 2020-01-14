using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
   
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private GameObject topBorder;
    [SerializeField] private GameObject bottomBorder;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    void FixedUpdate()
    {
        PlayerMove();

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
        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit raycastHit;

        if (Physics.Raycast(ray,out raycastHit)/*&& raycastHit.collider.gameObject.GetPhotonView().IsMine*/)
        {
            transform.position = raycastHit.point;

            float clampedX = Mathf.Clamp(transform.position.x, leftBorder.transform.position.x, rightBorder.transform.position.x);
            float clampedZ = Mathf.Clamp(transform.position.z, bottomBorder.transform.position.z, topBorder.transform.position.z);
            transform.position = new Vector3(clampedX, 1.35f, clampedZ);

        }
    }

    
}
