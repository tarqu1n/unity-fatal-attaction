using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{

    [Header("Global Game Setup")]
    [Space]
    public GameObject RestartPanel;
    public GameObject scoreTextObj;
    public AudioSource deathSound;

    [HideInInspector]
    public bool alive;

    private int score;
    private TextMeshProUGUI scoreText;
    public void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();

        alive = true;
        score = 0;

        Invoke("UpdateScore", 1f);
    }

    public void UpdateScore()
    {
        if (alive)
        {
            score++;
            scoreText.text = $"Score: {score.ToString()}";
            Invoke("UpdateScore", 1f);
        }
    }

    public void GoToGameScene()
    {
        alive = true;
        SceneManager.LoadScene("Game");
    }

    public void Restart ()
    {
        alive = true;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke("UpdateScore", 1f);

    }

    public void GoToMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        Invoke("ShowRestartPanel", 1.5f);
        deathSound.Play();
        alive = false;
    }

    public void ShowRestartPanel()
    {
        RestartPanel.SetActive(true);
    }
}
