using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheNextLevel : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject Player;

    public AudioSource audioSource;

    public GameObject portalMeshClosed;
    public GameObject portalClosed;

    public GameObject portalMeshOpened;
    public GameObject portalOpened;

    public GameObject blackHoleMesh;
    public GameObject blackHole;

    public GameObject first_canvas;
    public Animator transition_goal;
    public Animator transition_canvas;
    public Animator transition_score;
    public Animator transition_lives;
    public Animator transition_levelup;
    public Animator transition_countdown;
    public Animator transition_level_completed;

    [HideInInspector]
    public float end_duration = 3.0f;

    [HideInInspector]
    public float music_fade_duration = 3.0f;

    readonly private float seconds_duration = 2.0f;
    private bool openPortalsDeleted = false;

    readonly private int sceneIndexBeforeLast = 3;

    void Update()
    {
        if (openPortalsDeleted == false)
        {
            StartCoroutine(DeleteOpenPortals());
            openPortalsDeleted = true;
        }

        if (playerController.hexaGoalTrue == true)
        {
            first_canvas.SetActive(false);

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
        transition_countdown.SetTrigger("CountFadeOut");

        transition_level_completed.SetTrigger("LevelCompletedFadeInTrigger");
        Destroy(Player);

        yield return new WaitForSeconds(end_duration);

        transition_canvas.SetTrigger("FadeOutTrigger");

        StartCoroutine(FadeMusic());

        transition_level_completed.SetTrigger("LevelCompletedFadeOutTrigger");

        yield return new WaitForSeconds(end_duration);


        if (SceneManager.GetActiveScene().buildIndex < sceneIndexBeforeLast)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
            SceneManager.LoadScene("MainMenu");
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

    IEnumerator FadeMusic()
    {
        while (audioSource.volume > 0.0f)
        {
            audioSource.volume -= Time.deltaTime / music_fade_duration;
            yield return new WaitForSeconds(music_fade_duration);
        }
    }
}
