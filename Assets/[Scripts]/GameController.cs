using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float moveSpeed = 0.005f;
    public bool canMove = false;

    public void GameLoss()
    {
        moveSpeed = 0;
        //Time.timeScale = 0;
    }

    public void ShowEndUI(bool didWin)
    {

    }
}
