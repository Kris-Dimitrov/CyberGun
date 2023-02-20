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
    public float reloadSpeed;
    public int multishot;
    public int shotDelay;

    [SerializeField] public Inventory inventory;
    [SerializeField] private Dictionary<string, int> attributes;
    [SerializeField] public  float reloadProgress;
    [SerializeField] bool canShoot;
    [SerializeField] bool isReloading;

    public Camera cam;
    public LineRenderer lineRenderer;

    [SerializeField] GameObject bullet;

    public void Start()
    {
        inventory = new Inventory();
        inventory.Start();
        CheckStats();
        currentBulletsInMagazine = magazineSize;
        multishot = 1;
    }
    public void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            reloadProgress = reloadSpeed / 5;
            StartCoroutine(Reload());
        }

        if (isReloading)
        {
            reloadProgress -= 0.05f;
        }
    }
    public void Shoot()
    {
        if (currentBulletsInMagazine > 0 && canShoot)
        {
            if (inventory.core.Type == "HitScan")
            {
                FireHitScan();
                currentBulletsInMagazine--;
            }
            else if (inventory.core.Type == "Projectile")
            {
                FireProjectile();
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
            Vector3[] positions = { transform.position, hit.point };

            lineRenderer.SetPositions(positions);
            StartCoroutine(ShowLaser());
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * multishot);
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
        for (int i = 0; i < multishot; i++)
        {
            GameObject newBullet = Instantiate(bullet, transform);
            newBullet.transform.rotation = cam.transform.rotation;
            newBullet.transform.Rotate((Random.value - 0.5f) * accuracy * 50, (Random.value - 0.5f) * accuracy * 50, (Random.value - 0.5f) * accuracy * 50, Space.Self);
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shotSpeed, ForceMode.Impulse);
            newBullet.GetComponent<BulletScript>().damage = damage;
            newBullet.transform.SetParent(null);
        }
    }
    public void CheckStats()
    {
        attributes = inventory.CheckStats();
        foreach (var stat in attributes)
        {
            if (stat.Key == "Damage")
            {
                damage = stat.Value;
            }
            else if (stat.Key == "ShotSpeed")
            {
                shotSpeed = stat.Value;
            }
            else if (stat.Key == "ShotDelay")
            {
                shotDelay = stat.Value;
            }
            else if (stat.Key == "MagazineSize")
            {
                magazineSize = stat.Value;
            }
            else if (stat.Key == "ReloadSpeed")
            {
                reloadSpeed = 10 / stat.Value;
            }
            else if (stat.Key == "Accuracy")
            {
                accuracy = stat.Value / 10f;
            }
            else if (stat.Key == "'Multishot")
            {
                multishot += stat.Value;
            }
        }
    }

    IEnumerator Reload()
    {
        canShoot = false;
        Debug.Log("Reloading for " + reloadSpeed);
        yield return new WaitForSeconds(reloadSpeed);
        currentBulletsInMagazine = magazineSize;
        reloadProgress = 0;
        canShoot = true;
        isReloading = false;
    }

    IEnumerator ShowLaser()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lineRenderer.enabled = false;
    }
}
