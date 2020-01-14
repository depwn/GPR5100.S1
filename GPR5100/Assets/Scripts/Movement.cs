using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    bool clicked = true;
    bool canMove;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (clicked)
            {
                clicked = false;

                //checking if mouse position differs in the x axis < or >= than players(hockey pad) transform position.x
                //checking if mouse position differs in the z axis < or >= than players(hockey pad) transform position.z 
                // 7.5  is half the x hockey pad size. prolly needed. need validation ???
                if ((mousePosition.x >= transform.position.x && mousePosition.x < transform.position.x ||
                 mousePosition.x <= transform.position.x && mousePosition.x > transform.position.x ) &&
                 (mousePosition.z >= transform.position.z && mousePosition.z < transform.position.z  ||
                 mousePosition.z <= transform.position.z && mousePosition.z > transform.position.z )) 
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                //if clicked and able to move then moving the pad to the mouse position
                //transform.position = mousePosition;
                rb.MovePosition(mousePosition);
                
            }
           
        }
        else
        {
            clicked = true;
        }
    }
}
