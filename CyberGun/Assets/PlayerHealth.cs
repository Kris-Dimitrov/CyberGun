using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
