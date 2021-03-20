using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLifeCoins : MonoBehaviour
{
    public ParticleSystem extraLifeParticleSystem;

    [HideInInspector]
    public int extraLifeValue = 1;
    public Animator extraCanvasText;
    public AudioClip PickupAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            extraLifeParticleSystem.transform.SetParent(null);
            extraLifeParticleSystem.Play();

            AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

            extraCanvasText.SetTrigger("ExtraLifeFadeInTrigger");

            Destroy(gameObject);

            //FEEDBACK: pripaziti na kod koji se nalazi nakon Destroy metode
            //          postoji mogucnost da se nece izvrsit kako treba jer ce se objekt unistit
            //          to ujedno znaci i nestajanje ove skripte
            extraCanvasText.SetTrigger("ExtraLifeFadeOutTrigger");
        }
    }
}
