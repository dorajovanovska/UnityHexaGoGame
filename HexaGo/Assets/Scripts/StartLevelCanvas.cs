using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelCanvas : MonoBehaviour
{
    public Animator transition;
    public float duration = 1.0f;

    private bool startCanvasFinished = false;
    [HideInInspector]
    public bool startCanvasDisabled = false;

    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(LevelStart());
        }

        if(startCanvasFinished == true)
        {
            startCanvasDisabled = true;
        }
    }

    IEnumerator LevelStart()
    {
           transition.SetTrigger("FadeInTrigger");
           yield return new WaitForSeconds(duration);
           startCanvasFinished = true;
    }
}
