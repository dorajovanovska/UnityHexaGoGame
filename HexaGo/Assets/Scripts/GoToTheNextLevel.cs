using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheNextLevel : MonoBehaviour
{
    public PlayerController playerController;

    public GameObject portalMeshClosed;
    public GameObject portalClosed;

    public GameObject portalMeshOpened;
    public GameObject portalOpened;

    public GameObject blackHoleMesh;
    public GameObject blackHole;

    public Animator transition_goal;
    public Animator transition_canvas;
    public Animator transition_score;
    public Animator transition_lives;
    public Animator transition_levelup;
    public Animator transition_countdown;
    public Animator transition_level_completed;

    public float end_duration = 1.0f;

    readonly private float seconds_duration = 2.0f;
    private bool openPortalsDeleted = false;

    void Update()
    {
        if (openPortalsDeleted == false)
        {
            StartCoroutine(DeleteOpenPortals());
            openPortalsDeleted = true;
        }

        if (playerController.hexaGoalTrue == true)
        {
            transition_goal.SetTrigger("GoalAchievedFadeOutTrigger");

            portalClosed.GetComponent<MeshRenderer>().enabled = false;
            portalMeshClosed.GetComponent<MeshCollider>().enabled = false;

            portalOpened.GetComponent<MeshRenderer>().enabled = true;
            portalMeshOpened.GetComponent<MeshCollider>().enabled = true;

            blackHole.GetComponent<MeshRenderer>().enabled = true;
            blackHoleMesh.GetComponent<MeshCollider>().enabled = true;
        }

        if (playerController.playerBlackHoleTrigger == true)
        {
            StartCoroutine(GoToNextLevel());
        }

    }

    IEnumerator GoToNextLevel()
    {
        transition_score.SetTrigger("ScoreTextFadeOut");
        transition_lives.SetTrigger("LivesTextFadeOut");
        transition_levelup.SetTrigger("LevelUpFadeOutTrigger");
        transition_canvas.SetTrigger("FadeOutTrigger");
        transition_countdown.SetTrigger("CountFadeOut");
        transition_level_completed.SetTrigger("LevelCompletedFadeOutTrigger");
        yield return new WaitForSeconds(end_duration);
        SceneManager.LoadScene("Level_02");
    }

    IEnumerator DeleteOpenPortals()
    {
        portalOpened.GetComponent<MeshRenderer>().enabled = false;
        portalMeshOpened.GetComponent<MeshCollider>().enabled = false;

        blackHole.GetComponent<MeshRenderer>().enabled = false;
        blackHoleMesh.GetComponent<MeshCollider>().enabled = false;

        openPortalsDeleted = true;
        yield return new WaitForSeconds(seconds_duration);
    }
}
