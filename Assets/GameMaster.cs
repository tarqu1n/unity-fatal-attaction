﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    [Header("Global Game Setup")]
    [Space]
    public GameObject RestartPanel;

    [HideInInspector]
    public bool Alive;
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        Invoke("ShowRestartPanel", 1.5f);
    }

    public void ShowRestartPanel()
    {
        RestartPanel.SetActive(true);
    }
}
