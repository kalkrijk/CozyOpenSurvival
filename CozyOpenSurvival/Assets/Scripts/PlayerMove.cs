using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    private Vector3 moveDirection;
    bool isGrounded;


    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float playerHeight;
    [SerializeField] private float playerDrag;
    [SerializeField] private float airControl;
    [SerializeField] private float airDrag;

    
    void Start()
    {
        if(!IsOwner) return;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if(!IsOwner) return;
        CalculateDrag();
        Move();
    }

    void Move()
    {
        if(!IsOwner) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * vertical + transform.right * horizontal;

        if (isGrounded) 
        {
            rb.AddForce(moveDirection * moveSpeed * 10, ForceMode.Force);
        }
        else if (!isGrounded) 
        {
            rb.AddForce(moveDirection * moveSpeed * 10 * airControl, ForceMode.Force);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void CalculateDrag()
    {
        if (!IsOwner) return;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (isGrounded)
        {
            rb.drag = playerDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }
    private void Jump()
    {
        if (!IsOwner) return;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        IRemoveable removeable = other.GetComponent<IRemoveable>();
        if (removeable != null)
        {
            removeable.Remove();
        }
    }
}
