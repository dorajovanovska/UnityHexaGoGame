using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform RespawnTransform;
    public Animator transition;
 
    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();

        transition.SetTrigger("CheckpointFadeOut");

        if (healthManager == null)
        {
            return;
        }

        else healthManager._startingPosition = RespawnTransform.position;
    }
}
