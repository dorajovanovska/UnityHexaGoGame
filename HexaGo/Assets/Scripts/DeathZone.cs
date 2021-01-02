using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

        if (healthManager == null)
            return;

        healthManager.Die();
    }

}
