using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCoins : MonoBehaviour
{
    public AudioClip PickupAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

            Destroy(gameObject);
        }
    }
}
