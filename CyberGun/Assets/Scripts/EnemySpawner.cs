using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    private float timer;
    public float spawnTimer;
    [SerializeField] Transform spawnPosition;

    private void Start()
    {
        timer = 0;
    }

    public void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            timer = 0;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy() 
    {
       
        GameObject newEnemy = Instantiate(toSpawn,spawnPosition);
        //newEnemy.transform.SetParent(null);
        Debug.Log(newEnemy.tag);
    }
}
