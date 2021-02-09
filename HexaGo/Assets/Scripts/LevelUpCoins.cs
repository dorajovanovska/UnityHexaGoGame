using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCoins : MonoBehaviour
{
    public AudioClip PickupAudioClip;
    public ParticleSystem levelUpParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelUpParticleSystem.transform.SetParent(null);
            levelUpParticleSystem.Play();

            AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

            Destroy(gameObject);
        }
    }
}
