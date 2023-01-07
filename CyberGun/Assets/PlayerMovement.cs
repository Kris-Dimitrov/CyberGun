using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    float playerHeight = 2f;
    public float moveSpeed = 6f;
    [SerializeField] float drag = 6f;
    [SerializeField] float speedMult = 10f;
    [SerializeField] float dashMult = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 20f;
    [SerializeField] float slamMultiplier = 3f;
    [SerializeField] float airSpeedMultiplier = 0.5f;
    [SerializeField] float maxDashCount = 10f;
    [SerializeField] float dashConsumed = 10f;
    [SerializeField] float dashRecoverySpeed = 0.1f;


    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode slamKey = KeyCode.LeftControl;
    [SerializeField] KeyCode dashKey = KeyCode.LeftShift;

    bool isGrounded;
    bool canDoubleJump;
    bool canDash;

    float horizontalMovement;
    float verticalMovement;

    float currentDashAmount;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        ApplyDrag();

        canDoubleJump = true;

        currentDashAmount = maxDashCount;
    }
    void Update()
    {
        GetInput();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
        HandleJumps();
        Slam();
        Dash();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        DashCharger();
    }

    private void GetInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void ApplyDrag()
    {
        rb.drag = drag;
    }

    private void ApplyMovement()
    {
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * speedMult, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * speedMult * airSpeedMultiplier, ForceMode.Acceleration);
        }

    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void HandleJumps()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(jumpKey) && !isGrounded && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }

        if (isGrounded)
        {
            canDoubleJump = true;
        }
    }

    private void Slam()
    {

        if (Input.GetKey(slamKey) && !isGrounded)
        {
            Vector3 currentG = gravity * slamMultiplier * Vector3.up;
            rb.AddForce(currentG, ForceMode.Acceleration);
        }
        else
        {
            Vector3 currentG = gravity * Vector3.up;
            rb.AddForce(currentG, ForceMode.Acceleration);
        }
    }

    private void Dash() 
    {
        if (currentDashAmount >= dashConsumed && Input.GetKeyDown(dashKey))
        {
            rb.AddForce(transform.forward * dashMult, ForceMode.Impulse);
            currentDashAmount -= dashConsumed;
        }

    }

    private void DashCharger() 
    {
        if (currentDashAmount < maxDashCount)
        {
            currentDashAmount += dashRecoverySpeed;
        }
    }
}
