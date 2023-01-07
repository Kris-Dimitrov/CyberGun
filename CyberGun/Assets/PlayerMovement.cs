using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    float drag = 6f;
    float speedMult = 10f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        Move();
        ApplyDrag();
    }

    private void Move()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void ApplyDrag() 
    {
        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        ApplyForces();
    }

    private void ApplyForces() 
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * speedMult, ForceMode.Acceleration);
    }
}
