using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    GameObject player;
    [SerializeField] Rigidbody rb;
    void Start()
    {   
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        rb.AddForce(transform.forward, ForceMode.Acceleration);
    }
}
