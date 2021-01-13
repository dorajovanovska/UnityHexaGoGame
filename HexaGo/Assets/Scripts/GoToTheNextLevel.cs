using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheNextLevel : MonoBehaviour
{
    public PlayerController playerController;
    public Animator transition_goal;
    public Animator transition_canvas;
    public Animator transition_score;
    public Animator transition_lives;
    public Animator transition_levelup;
    public Animator transition_countdown;
    public float end_duration = 0.1f;

    void Update()
    {
        if (playerController.hexaGoalTrue == true)
        {
            transition_goal.SetTrigger("GoalAchievedFadeOutTrigger");
        }
            
    }

    IEnumerator GoToNextLevel()
    {
        transition_score.SetTrigger("ScoreTextFadeOut");
        transition_lives.SetTrigger("LivesTextFadeOut");
        transition_levelup.SetTrigger("LevelUpFadeOutTrigger");
        transition_canvas.SetTrigger("FadeOutTrigger");
        transition_countdown.SetTrigger("CountFadeOut");
        yield return new WaitForSeconds(end_duration);
        SceneManager.LoadScene("Level_02");
    }
}
