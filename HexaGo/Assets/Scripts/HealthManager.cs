using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int StartingHealth = 0;
    public int Health = 0;
    public int NumberOfLives = 2;

    public Vector3 _startingPosition;

    public Text LivesText;

    private void Start()
    {
        Health = StartingHealth;
        _startingPosition = transform.position;

        LivesText.text = "Lives: " + NumberOfLives.ToString();
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

        LivesText.text = "Lives: " + NumberOfLives.ToString();

        transform.position = _startingPosition;

        if (NumberOfLives < 1)
        {
            GameManager.Instance.GameOverCanvas.gameObject.SetActive(true);
            Destroy(gameObject);
            LivesText.text = "Lives: 0";
        }
    }
}
