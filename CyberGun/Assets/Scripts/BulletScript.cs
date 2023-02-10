using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage;
    float initTime;
    [SerializeField]float timeBeforeDestroy;

    Rigidbody rb;

    private void Start()
    {
        initTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        float timeSinceStart = Time.timeSinceLevelLoad - initTime;

        if (timeSinceStart >= timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
