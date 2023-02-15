using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] int damage;
    [SerializeField] bool destroyOnContact;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (destroyOnContact)
        {
            Destroy(this.gameObject);
        }
    }

}
