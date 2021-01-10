using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public GameObject textDisplay;

    [Tooltip("Duration of current level in seconds.")]
    public int timerDuration = 5;
    private int secondsLeft = 0;
    
    private bool takingAway = false;
    readonly private int secondDuration = 1;
    readonly private int zeroSeconds = 0;

    private bool timerFinishedIsTrue = false;

    private void Start()
    {
        secondsLeft = timerDuration;

        TimeFormat();
    }

    private void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());  
        }

        if (secondsLeft == 0 && timerFinishedIsTrue == false)
        {
            StartCoroutine(TimerFinished());
            timerFinishedIsTrue = true;

            takingAway = false;
            secondsLeft = timerDuration + secondDuration;
            timerFinishedIsTrue = false;
        }

        HealthManager healthManager = GetComponent<HealthManager>();
        if (healthManager.PlayerDied == true)
        {
            StartCoroutine(PlayerDied());
            secondsLeft = timerDuration + secondDuration;
        }
    }

    IEnumerator PlayerDied()
    {
        HealthManager healthManager = GetComponent<HealthManager>();
        healthManager.PlayerDied = false;
        yield return new WaitForSeconds(zeroSeconds);
    }

    IEnumerator TimerFinished()
    {
        HealthManager healthManager = GetComponent<HealthManager>();
        healthManager.Die();
        yield return new WaitForSeconds(secondDuration);
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(secondDuration);
        secondsLeft -= 1;

        TimeFormat();
       
        takingAway = false;
    }

    
    private void TimeFormat()
    {
        float seconds = secondsLeft % 60;
        float minutes = (int)(secondsLeft / 60) % 60;
        textDisplay.GetComponent<Text>().text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }

}
