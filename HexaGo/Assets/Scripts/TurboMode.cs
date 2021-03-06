﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboMode : MonoBehaviour
{
    public GameObject Player;
    public GameObject Turbo;
    public ParticleSystem turboParticleSystem;

    public Animator turboCollectedFadeOut;
    public Animator turboCanvasFadeIn;
    public Animator turboCanvasFadeOut;
    public Animator turboCanvasNull;
    public AudioClip turboAudioClip;

    public float movementSpeedTurbo = 20.0f;
    public float jumpHeightTurbo = 20.0f;
    [Tooltip("Duration of Turbo Mode in seconds.")]
    public int turboDuration = 3;

    [HideInInspector]
    public bool turboAndPlayerColided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turbo")
        {
            turboParticleSystem.transform.SetParent(null);
            turboParticleSystem.Play();

            AudioSource.PlayClipAtPoint(turboAudioClip, transform.position);

            turboCollectedFadeOut.SetTrigger("TurboCollectedFadeOut");
            turboCanvasFadeIn.SetTrigger("TurboCanvasFadeIn");

            turboAndPlayerColided = true;
            Destroy(Turbo);
        }
    }
}
