using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool isOnGround = true;
    private float _horizontal;
    private float _vertical;
    private Rigidbody _rigidbody;
    private Vector3 _baseGravity = new Vector3(0, -9.81f, 0);

    void Start()
    {
         _rigidbody = GetComponent<Rigidbody>();     
        Physics.gravity = _baseGravity;
        Physics.gravity *= GravityModifier;
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector3(_horizontal * moveSpeed, _rigidbody.velocity.y, _vertical * moveSpeed);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if(other.gameObject.CompareTag("Platform"))
        {
            
        }
    }

}