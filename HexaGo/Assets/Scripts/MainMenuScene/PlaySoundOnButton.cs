using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverAudioClip;
    public AudioClip clickAudioClip;

    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverAudioClip);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickAudioClip);
    }
}
