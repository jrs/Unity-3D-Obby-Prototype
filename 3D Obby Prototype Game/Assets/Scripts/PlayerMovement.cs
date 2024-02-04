using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float moveSpeed = 1.0f;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool isOnGround = true;
    private float horizontal;
    private float vertical;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);

        _rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.deltaTime);
        _rigidbody.MoveRotation(_rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

}