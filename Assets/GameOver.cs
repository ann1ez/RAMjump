using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameController gamecontroller;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gamecontroller.isGameOver = true;
        }
    }
}
