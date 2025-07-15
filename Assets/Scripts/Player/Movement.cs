using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public Transform orientation;
    public Transform playerBodyTransform;
    public bool lockMovement = false;

    [Header("Animation & Sound")]
    public Animator animator;
    public AudioClip[] walkClips;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float horizontalInput;
    private float verticalInput;
    private bool isMoving = false;
    private bool wasMoving = false;

    private Coroutine footstepCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        GetInput();
        HandleAnimation();
        HandleFootsteps();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isMoving = horizontalInput != 0 || verticalInput != 0;
    }

    private void HandleAnimation()
    {
        if (isMoving != wasMoving)
        {
            animator.SetBool("isMoving", isMoving);
            wasMoving = isMoving;
        }
    }

    private void HandleFootsteps()
    {
        if (isMoving && footstepCoroutine == null)
        {
            footstepCoroutine = StartCoroutine(FootstepSound());
        }
        else if (!isMoving && footstepCoroutine != null)
        {
            StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }
    }

    private IEnumerator FootstepSound()
    {
        while (true)
        {
            SFXManager.Instance.PlayRandomSFX(walkClips, volume: 20f);
            yield return new WaitForSeconds(0.45f);
        }
    }

    private void MovePlayer()
    {
        if (!lockMovement)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.velocity = moveDirection.normalized * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        }
    }
}
