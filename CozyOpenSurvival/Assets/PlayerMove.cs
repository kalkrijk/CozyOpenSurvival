using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        CalculateDrag();
        Move();
    }

    void Move()
    {
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
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Force);
    }
}
