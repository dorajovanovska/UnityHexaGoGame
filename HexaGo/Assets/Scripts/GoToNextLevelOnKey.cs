using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevelOnKey : MonoBehaviour
{
    public Animator transition;
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
        transition.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(end_duration);
        SceneManager.LoadScene("Level_02");
    }
}
