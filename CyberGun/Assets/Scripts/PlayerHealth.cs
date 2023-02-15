using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void Heal(int healing) 
    {
        health += healing;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void IncreaseMaxHealth(int amount) 
    {
        maxHealth += amount;
        Heal(amount);
    }
}
