using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject ballMesh;
    public Material ballDefaultMaterial;
    public Material ballPurpleMaterial;
    public Material ballOrangeMaterial;

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

    void FixedUpdate()
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

        
        _rigidbody.AddForce(direction * MovementSpeed);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsOnThePlatform == true)
        {
            _rigidbody.AddForce(new Vector3(0.0f, JumpHeight, 0.0f), ForceMode.Impulse);
            IsOnThePlatform = false;
        }
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
        //FEEDBACK: kada igra krene u smjeru da ima potrebnu za puno razlicitih tagova to znaci da treba razmislit o drugom rijesenju
        //          ukoliko netko promijeni tag ili se ovdje desi tipfeler nece raditi kako treba
        //          koristit recimo komponente kao filtar za pojedine tipove
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
                ballMesh.GetComponent<MeshRenderer>().material = ballPurpleMaterial;
                ballDefaultMaterial = ballPurpleMaterial;
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
        ballMesh.GetComponent<MeshRenderer>().material = ballOrangeMaterial;

        turboFinished = false;

        TurboMode turbomode = GetComponent<TurboMode>();
        MovementSpeed = turbomode.movementSpeedTurbo;
        JumpHeight = turbomode.jumpHeightTurbo;

        HealthManager healthmanager = GetComponent<HealthManager>();

        if(healthmanager.PlayerDiedWithTurbo == true)
        {
            turbomode.turboAndPlayerColided = false;
            turboFinished = true;
            turbomode.turboCanvasNull.SetTrigger("TurboCanvasNull");
            ballMesh.GetComponent<MeshRenderer>().material = ballDefaultMaterial;
        }

        yield return new WaitForSeconds(turbomode.turboDuration);

        ballMesh.GetComponent<MeshRenderer>().material = ballDefaultMaterial;

        turbomode.turboAndPlayerColided = false;

        turboFinished = true;

        turbomode.turboCanvasFadeOut.SetTrigger("TurboCanvasFadeOut");
    }
}
