using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float MovementSpeed = 5.0f;
    public float JumpHeight = 10.0f;

    private float _moveHorizontal = 0.0f;
    private float _moveVertical = 0.0f;

    private bool IsOnThePlatform = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

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
}
