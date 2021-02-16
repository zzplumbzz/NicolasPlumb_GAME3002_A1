using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallScript : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            var ball = other.gameObject.GetComponent<BallScript>();
            
            ball.transform.position = spawnPoint.position;
            
           
        }
    }
}
