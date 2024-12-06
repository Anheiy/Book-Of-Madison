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
    public static bool lockMovement = false;
    Vector3 moveDirection;
    int degrees = 0;
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
    public void DegreesCalculation(Vector2 Direction)
    {
        if (Direction == Vector2.zero)
            degrees = clampTo360(0 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x > 0 && Direction.y > 0)
            degrees = clampTo360(45 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x > 0 && Direction.y == 0)
            degrees = clampTo360(90 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x > 0 && Direction.y < 0)
            degrees = clampTo360(135 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x == 0 && Direction.y < 0)
            degrees = clampTo360(180 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x < 0 && Direction.y < 0)
            degrees = clampTo360(225 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x < 0 && Direction.y == 0)
            degrees = clampTo360(270 - playerBodyTransform.eulerAngles.y);
        else if (Direction.x < 0 && Direction.y > 0)
            degrees = clampTo360(315 - playerBodyTransform.eulerAngles.y);
    }
    public int clampTo360(float value)
    {
        if(value > 360)
        {
            return roundTo45(value - 360);
        }
        else if(value < 0)
        {
            return roundTo45(value + 360);
        }
        return roundTo45(value);
    }
    public int roundTo45(float value)
    {
        return (int)(Mathf.Round(value / 45) * 45);
    }
}
