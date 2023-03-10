using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHelath;
    [SerializeField] private int health;

    [SerializeField] int points;
    [SerializeField] ParticleSystem explosion;

    public void Start()
    {
        health = startingHelath;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddToScore(points);
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() 
    {
        explosion.Play();
        yield return new WaitForSeconds(explosion.main.startLifetime.constant);
        Destroy(this.gameObject);
    }
}
