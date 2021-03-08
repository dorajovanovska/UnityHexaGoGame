using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAchievedCutscene : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public PlayerController playerController;
    readonly private float cutsceneDuration = 2.5f;
    private bool cutsceneFinished = false;

    readonly private float timeStop = 0.0f;
    readonly private float timeResume = 1.0f;

    public PauseLevelCanvas pauseLevelCanvas;

    void Start()
    {
        mainCamera.enabled = true;
        cutsceneCamera.enabled = false;
    }


    void Update()
    {
        if(playerController.hexaGoalTrue == true)
        {
            StartCoroutine(EnableGoalAchievedCutscene());

            if(cutsceneFinished == true)
            {
                StopCoroutine(EnableGoalAchievedCutscene());
                Time.timeScale = timeResume;
                pauseLevelCanvas.enabled = true;
                mainCamera.enabled = true;
                cutsceneCamera.enabled = false;
                this.enabled = false;
            }
        }
    }

    IEnumerator EnableGoalAchievedCutscene()
    {
        pauseLevelCanvas.enabled = false;
        Time.timeScale = timeStop;
        mainCamera.enabled = false;
        cutsceneCamera.enabled = true;
        yield return new WaitForSecondsRealtime(cutsceneDuration);
        cutsceneFinished = true;
    }
}
