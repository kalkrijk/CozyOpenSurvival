using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;


    [SerializeField] private Transform playerOrientation;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LayerMask whatIsGround;
    bool isGrounded;
    [SerializeField] private int playerHeight;


    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = playerOrientation.forward * vertical + playerOrientation.right * horizontal;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }
}
