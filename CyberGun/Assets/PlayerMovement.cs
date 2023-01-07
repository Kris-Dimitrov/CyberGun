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
    [SerializeField] float jumpForce = 10f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    bool isGrounded;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ApplyDrag();
    }
    void Update()
    {
        GetInput();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }



    private void FixedUpdate()
    {
        ApplyForces();
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

    private void ApplyForces() 
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * speedMult, ForceMode.Acceleration);
    }

    private void Jump() 
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

}
