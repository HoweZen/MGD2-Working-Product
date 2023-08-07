using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Kill the player
        if (collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }

}
