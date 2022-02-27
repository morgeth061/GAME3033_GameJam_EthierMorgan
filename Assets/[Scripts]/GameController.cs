using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;
    public float moveSpeed = 0.005f;
    public bool canMove = false;
    private bool pauseVisible = false;
    private float tempSpeed;

    void Start()
    {
        tempSpeed = moveSpeed;
    }

    public void GameLoss()
    {
        moveSpeed = 0.0f;
        
        //Time.timeScale = 0;
    }

    public void ShowEndUI(bool didWin)
    {
        if (didWin)
        {
            winMenu.transform.Find("WinText").gameObject.GetComponent<TextMeshProUGUI>().text = "You won!";
        }
        else
        {
            winMenu.transform.Find("WinText").gameObject.GetComponent<TextMeshProUGUI>().text = "You lost...";
        }
        winMenu.SetActive(true);
        Time.timeScale = 0;
        moveSpeed = 0.0f;
    }

    public void Pause()
    {
        if (!pauseVisible)
        {
            pauseVisible = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            moveSpeed = 0.0f;
        }
        else
        {
            pauseVisible = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            moveSpeed = tempSpeed;
        }
    }

    public void OnPauseClick()
    {
        Pause();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
