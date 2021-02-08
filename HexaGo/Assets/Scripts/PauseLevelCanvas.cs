using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevelCanvas : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public Animator firstCanvas;

    readonly private float timeStop = 0.0f;
    readonly private float zeroSeconds = 0.0f;
    readonly private float timeStart = 1.0f;
    private bool timeStopped = false;

    public HealthManager healthManager;
    public PlayerController playerController;

    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        StartLevelCanvas startLevelCanvas = GetComponent<StartLevelCanvas>();
        if (startLevelCanvas.startCanvasDisabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(timeStopped == false)
                {
                    pauseMenuCanvas.SetActive(true);

                    StartCoroutine(StopTime());
                    if(timeStopped == true)
                    {
                        StopCoroutine(StopTime());
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(timeStopped == true)
                {
                    pauseMenuCanvas.SetActive(false);
                    StartCoroutine(ResumeTime());
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(playerController.playerBlackHoleTrigger == true)
                {
                    firstCanvas.SetTrigger("FadeOutTrigger");
                    pauseMenuCanvas.SetActive(false);
                    StartCoroutine(ResumeTime());
                }
            }

            if(healthManager.ZeroLives == true)
            {
                firstCanvas.SetTrigger("FadeOutTrigger");
                pauseMenuCanvas.SetActive(false);
                StartCoroutine(ResumeTime());
            }
        }
    }

    IEnumerator StopTime()
    {
        Time.timeScale = timeStop;
        yield return new WaitForSeconds(zeroSeconds);
        timeStopped = true;
    }

    IEnumerator ResumeTime()
    {
        timeStopped = false;
        Time.timeScale = timeStart;
        yield return new WaitForSeconds(zeroSeconds);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = timeStart;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
