using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HealthManager healthManager;

    static public int Score = 0;
    private int ScoreAfterGameRestart = 0;
    public Text ScoreText;
    public GameObject GameOverCanvas;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        GameOverCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        ScoreText.text = "Score: " + Score.ToString();
        ScoreAfterGameRestart = Score;
    }

    public void UpdateScore(int value)
    {
        Score += value;

        if (Score < 0)
        {
            Score = 0;
        }

        ScoreText.text = "Score: " + Score.ToString();
    }

    public void RestartLevel()
    {
        Score = ScoreAfterGameRestart;
        healthManager.RestartLives();
        SceneManager.LoadScene("MainMenu");
    }

}
