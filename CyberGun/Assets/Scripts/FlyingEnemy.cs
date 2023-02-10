using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    GameObject player;
    [SerializeField] Rigidbody rb;
    [SerializeField] int speed;
    void Start()
    {   
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        rb.velocity = transform.forward * speed;
            
    }
}
