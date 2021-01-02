using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform RespawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();

        if (healthManager == null)
        {
            return;
        }

        else healthManager._startingPosition = RespawnTransform.position;
    }

}
