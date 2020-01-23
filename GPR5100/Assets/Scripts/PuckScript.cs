using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript Score;
    public bool goal;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        goal = false;

    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
