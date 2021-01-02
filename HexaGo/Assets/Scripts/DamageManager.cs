using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int Damage = 50;

    private void OnCollisionEnter(Collision collision)
    {
        HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

        if (healthManager == null)
            return;

        healthManager.TakeDamage(Damage);
    }
}
