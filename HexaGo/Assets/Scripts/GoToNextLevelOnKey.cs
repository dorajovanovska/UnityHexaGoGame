using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevelOnKey : MonoBehaviour
{
    public Animator transition;
    public Animator transition_score;
    public Animator transition_lives;
    public Animator transition_countdown;
    public float end_duration = 0.1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            StartCoroutine(GoToNextLevel());
        }
            
    }

    IEnumerator GoToNextLevel()
    {
        transition_score.SetTrigger("ScoreTextFadeOut");
        transition_lives.SetTrigger("LivesTextFadeOut");
        transition.SetTrigger("FadeOutTrigger");
        transition_countdown.SetTrigger("CountFadeOut");
        yield return new WaitForSeconds(end_duration);
        SceneManager.LoadScene("Level_02");
    }
}
