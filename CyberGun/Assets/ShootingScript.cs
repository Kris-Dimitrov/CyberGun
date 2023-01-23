using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public float damage;
    public float shotSpeed;
    public int magazineSize;
    public int currentBulletsInMagazine;
    public int reloadSpeed;

    public Inventory inventory;
    private Dictionary<string, int> attributes;

    public Camera cam;
    

    public void Start()
    {
        attributes = inventory.CheckStats();
    }

    public void Shoot() 
    {
        if (attributes.ContainsKey("HitScan") && currentBulletsInMagazine > 0)
        {
            FireHitScan();
            currentBulletsInMagazine--;
        }
    }
    public void FireHitScan() 
    {
        
    }
    public void FireProjectile()
    {

    }
    public void FireLaser()
    {

    }

    public void CheckStats() 
    {
        attributes = inventory.CheckStats();
    }

    public void Reload() 
    {
    
    }
}
