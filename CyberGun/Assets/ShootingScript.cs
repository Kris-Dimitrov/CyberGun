using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public LineRenderer lineRenderer;
    

    public void Start()
    {   
        inventory = new Inventory();
        inventory.Start();
        attributes = inventory.CheckStats();
        CheckStats();
        currentBulletsInMagazine = magazineSize;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    public void Shoot() 
    {
        if (currentBulletsInMagazine > 0)
        {
            if (inventory.core.Type == "HitScan")
            {
                FireHitScan();
                currentBulletsInMagazine--;
            }
        }
    }
    public void FireHitScan() 
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3[] positions = { transform.position, cam.transform.forward * hit.distance };
            lineRenderer.SetPositions(positions);
            Debug.Log("Did Hit");
        }
        else
        {
            Vector3[] positions = { transform.position, cam.transform.forward * 1000 };
            lineRenderer.SetPositions(positions);
            Debug.Log("Did not Hit");
        }
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
        foreach(var stat in attributes) 
        {
            if (stat.Key == "Damage")
            {
                damage = stat.Value;
            }
            else if (stat.Key == "ShotSpeed") 
            {
                shotSpeed = stat.Value;
            }
            else if (stat.Key == "MagazineSize")
            {
                magazineSize = stat.Value;
            }
            else if (stat.Key == "ReloadSpeed")
            {
                reloadSpeed = stat.Value;
            }
        }
    }

    public void Reload() 
    {
        currentBulletsInMagazine = magazineSize;
    }
}
