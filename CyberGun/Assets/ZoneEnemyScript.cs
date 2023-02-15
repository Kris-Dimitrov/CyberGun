using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEnemyScript : MonoBehaviour
{
    public int damage;
    private Transform player;
    [SerializeField] float minimalDistanceToTrigger;

    [SerializeField] float maxCharge;
    [SerializeField] float currentCharge;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < minimalDistanceToTrigger)
        {
            currentCharge += Time.deltaTime;
            Debug.Log(currentCharge);
        }

        if (currentCharge >= maxCharge)
        {
            currentCharge = 0;
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
