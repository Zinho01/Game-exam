using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public GameManager theGM;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
          Debug.Log("YOU WIN");
          theGM.Victory();
        }
    }
    
}
