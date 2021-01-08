using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboMode : MonoBehaviour
{
    public GameObject Player;
    public GameObject Turbo;
    public Animator turboCollectedFadeOut;
    public AudioClip turboAudioClip;

    public float movementSpeedTurbo = 10.0f;
    public float jumpHeightTurbo = 15.0f;

    [HideInInspector]
    public bool turboAndPlayerColided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turbo")
        {
            AudioSource.PlayClipAtPoint(turboAudioClip, transform.position);
            turboCollectedFadeOut.SetTrigger("TurboCollectedFadeOut");
            turboAndPlayerColided = true;
            Destroy(Turbo);
        }
    }
}
