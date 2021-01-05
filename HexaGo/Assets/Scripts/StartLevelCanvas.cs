using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelCanvas : MonoBehaviour
{
    public Animator transition;
    public float duration = 1.0f;

    void Update()
    {
        StartCoroutine(LevelStart());
    }

    IEnumerator LevelStart()
    {
        if (Input.anyKey)
        {
            transition.SetTrigger("FadeInTrigger");
            yield return new WaitForSeconds(duration);
        }
    }
}
