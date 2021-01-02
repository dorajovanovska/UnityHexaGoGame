using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeCoins : MonoBehaviour
{
    public int Value = -50;
    public AudioClip PickupAudioClip;
    public ParticleSystem NegativeCoinParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

            GameManager.Instance.UpdateScore(Value);

            NegativeCoinParticleSystem.transform.SetParent(null);
            NegativeCoinParticleSystem.Play();

            Destroy(gameObject);
        }
    }
}
