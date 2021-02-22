using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public TurboMode turboMode;

    public int StartingHealth = 0;
    public int Health = 0;
    static public int NumberOfLives = 3;

    [HideInInspector]
    public bool PlayerDied = false;

    [HideInInspector]
    public bool PlayerDeath = false;

    [HideInInspector]
    public bool PlayerDiedWithTurbo = false;

    [HideInInspector]
    public bool ZeroLives = false;

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

        PlayerDied = true;

        PlayerDeath = true;

        if (turboMode.turboAndPlayerColided == true)
        {
            PlayerDiedWithTurbo = true;
        }

        LivesText.text = "Lives: " + NumberOfLives.ToString();

        transform.position = _startingPosition;

        if (NumberOfLives < 1)
        {
            ZeroLives = true;
            GameManager.Instance.GameOverCanvas.gameObject.SetActive(true);
            Destroy(gameObject);
            LivesText.text = "Lives: 0";
        }
    }

    public void AddExtraLife()
    {
        NumberOfLives++;
        LivesText.text = "Lives: " + NumberOfLives.ToString();
    }
}
