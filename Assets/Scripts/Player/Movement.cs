using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;
    public Transform playerBodyTransform;
    float horizontalInput;
    float verticalInput;
    public bool lockMovement = false;
    Vector3 moveDirection;
    public Animator animator;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    
    public void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("isMoving", true);
            Debug.Log("True");
        }
        else
        {
            animator.SetBool("isMoving", false);
            Debug.Log("False");
        }
    }

    public void MovePlayer()
    {
        if (!lockMovement)
        {
            //need to decide movement
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        }
    }
}
