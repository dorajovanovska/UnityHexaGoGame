﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform RespawnTransform;
    public Animator transition;
    public AudioClip checkpointAudioClip;
    public ParticleSystem checkpointParticleSystem;
    readonly private float secondDuration = 1.0f;
    private float volume = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();

        StartCoroutine(ClipPlayed());

        checkpointParticleSystem.transform.SetParent(null);
        checkpointParticleSystem.Play();

        transition.SetTrigger("CheckpointFadeOut");

        if (healthManager == null)
        {
            return;
        }

        else healthManager._startingPosition = RespawnTransform.position;

        Destroy(gameObject);
    }

    IEnumerator ClipPlayed()
    {
        AudioSource.PlayClipAtPoint(checkpointAudioClip, transform.position, volume);
        volume = 0.0f;
        yield return new WaitForSeconds(secondDuration);
    }
}
