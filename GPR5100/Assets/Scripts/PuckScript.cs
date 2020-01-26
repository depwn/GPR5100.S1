using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (other.tag == "TopGoal")
            {
                Score.IncreaseScore(ScoreScript.Score.FirstPlayerScore);
                goal = true;
                StartCoroutine(ResetPosition());
            }
            else if (other.tag == "BottomGoal")
            {
                Score.IncreaseScore(ScoreScript.Score.SecondPlayerScore);
                goal = true;
                StartCoroutine(ResetPosition());
            }
       }
    }

    private IEnumerator ResetPosition()
    {
        yield return new WaitForSecondsRealtime(1);
        goal = false;
        rb.velocity = rb.position = new Vector3(0f, 1.25f, 0f);
    }
}
