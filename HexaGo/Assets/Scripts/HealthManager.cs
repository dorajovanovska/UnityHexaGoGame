using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int StartingHealth = 0;
    public int Health = 0;
    public int NumberOfLives = 0;

    public Vector3 _startingPosition;

    private void Start()
    {
        Health = StartingHealth;
        _startingPosition = transform.position;
    }

    public void TakeDamage (int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Die();
    }

    public void Die()
    {
        Health = StartingHealth;
        NumberOfLives--;

        transform.position = _startingPosition;

        if (NumberOfLives < 0)
        {
            GameManager.Instance.GameOverCanvas.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
