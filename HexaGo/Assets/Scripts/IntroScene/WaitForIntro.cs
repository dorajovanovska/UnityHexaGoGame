using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForIntro : MonoBehaviour
{
    public float intro_duration = 7.0f;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(intro_duration);
        SceneManager.LoadScene(1);
    }
}
