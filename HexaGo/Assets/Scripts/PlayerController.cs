using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float MovementSpeed = 10.0f;
    public float JumpHeight = 15.0f;

    private float _moveHorizontal = 0.0f;
    private float _moveVertical = 0.0f;

    private bool IsOnThePlatform = true;

    [HideInInspector]
    public bool PlayerCheckpointTrigger = false;

    private float MovementAfterTurbo = 0.0f;
    private float JumpHeightAfterTurbo = 0.0f;

    private bool turboFinished = false;

    private int hexaCounter = 0;

    public Text LevelUpText;

    [HideInInspector]
    public int hexaGoal = 5;

    [HideInInspector]
    public bool hexaGoalTrue = false;

    [HideInInspector]
    public bool playerBlackHoleTrigger = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        MovementAfterTurbo = MovementSpeed;
        JumpHeightAfterTurbo = JumpHeight;
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

        TurboMode turbomode = GetComponent<TurboMode>();
        if (turbomode.turboAndPlayerColided == true)
        {
            if(turboFinished == false)
            {
                StartCoroutine(TurboDuration());
            }
        }

        if (turbomode.turboAndPlayerColided == false)
        {
            MovementSpeed = MovementAfterTurbo;
            JumpHeight = JumpHeightAfterTurbo;
        }

        if (Input.GetButtonDown("Jump") && IsOnThePlatform == true)
        {
            _rigidbody.AddForce(new Vector3(0.0f, JumpHeight, 0.0f), ForceMode.Impulse);
            IsOnThePlatform = false;
        }

        _rigidbody.AddForce(direction * MovementSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            IsOnThePlatform = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            PlayerCheckpointTrigger = true;
        }

        if(other.gameObject.tag == "ExtraLifeCoin")
        {
            HealthManager healthManager = GetComponent<HealthManager>();
            healthManager.AddExtraLife();
        }

        if(other.gameObject.tag == "LevelUpCoin")
        {
            hexaCounter++;
            LevelUpText.text = "Goal: " + hexaCounter + "/5";

            if (hexaCounter == hexaGoal)
            {
                hexaGoalTrue = true;
            }

            if(hexaCounter > hexaGoal)
            {
                hexaCounter = hexaGoal;
                LevelUpText.text = "Goal: " + hexaCounter + "/5";
            }
        }

        if(other.gameObject.tag == "BlackHole")
        {
            playerBlackHoleTrigger = true;
        }
    }


    IEnumerator TurboDuration()
    {
        turboFinished = false;

        TurboMode turbomode = GetComponent<TurboMode>();
        MovementSpeed = turbomode.movementSpeedTurbo;
        JumpHeight = turbomode.jumpHeightTurbo;

        HealthManager healthmanager = GetComponent<HealthManager>();

        if(healthmanager.PlayerDied == true)
        {
            turbomode.turboAndPlayerColided = false;
            turboFinished = true;
            turbomode.turboCanvasNull.SetTrigger("TurboCanvasNull");
        }

        yield return new WaitForSeconds(turbomode.turboDuration);

        turbomode.turboAndPlayerColided = false;

        turboFinished = true;

        turbomode.turboCanvasFadeOut.SetTrigger("TurboCanvasFadeOut");
    }
}
