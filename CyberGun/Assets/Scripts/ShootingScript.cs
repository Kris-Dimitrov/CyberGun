using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public int damage;
    public float shotSpeed;
    public float accuracy;
    public int magazineSize;
    public int currentBulletsInMagazine;
    public int reloadSpeed;

    [SerializeField]
    public Inventory inventory;
    private Dictionary<string, int> attributes;

    public Camera cam;
    public LineRenderer lineRenderer;
    

    public void Start()
    {   
        inventory = new Inventory();
        inventory.Start();
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
        ray.direction = new Vector3(ray.direction.x + (Random.value - 0.5f) * accuracy, ray.direction.y + (Random.value - 0.5f) * accuracy, ray.direction.z + (Random.value - 0.5f) * accuracy);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3[] positions = { transform.position, hit.point};
            
            lineRenderer.SetPositions(positions);
            StartCoroutine(ShowLaser());
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage );
            }
        }
        else
        {
            Vector3[] positions = { transform.position, ray.direction * 1000 };
            lineRenderer.SetPositions(positions);
            StartCoroutine(ShowLaser());
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
            else if (stat.Key == "Accuracy") 
            {
                accuracy = stat.Value / 10f;
            }
        }
    }

    public void Reload() 
    {
        currentBulletsInMagazine = magazineSize;
    }

    IEnumerator ShowLaser() 
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lineRenderer.enabled = false;
    }
}
