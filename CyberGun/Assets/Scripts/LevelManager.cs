using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public int round;
    public Vector2 arenaSize;

    [SerializeField] GameObject FlyingEnemy;
    [SerializeField] GameObject GroundSpawner;
    [SerializeField] GameObject Turrets;
    
    [SerializeField] GameObject FlyingEnemySpawnPositions;

    public int numberOfEnemies;
    private Transform[] flyingSpawnPositions;

    [SerializeField]ShopManager shopManager;

    private void Start()
    {
        flyingSpawnPositions = FlyingEnemySpawnPositions.GetComponentsInChildren<Transform>();
        SpawnNewRound();
    }

    private void FixedUpdate()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (numberOfEnemies == 0 && !shopManager.isShopActive)
        {
            round++;
            StartCoroutine(SpawnNewRound());
        }
    }

    IEnumerator SpawnNewRound()
    {
        shopManager.DisplayShop();
        yield return new WaitUntil(() => !shopManager.isShopActive);
        SpawnFlyingEnemies(round);
        SpawnGroundSpawners(round);
        SpawnTurretEnemies(round);
    }

    private void SpawnFlyingEnemies(int n) 
    {
        for (int i = 0; i < n; i++)
        {
            Transform spawnPos = flyingSpawnPositions[Random.Range(0, flyingSpawnPositions.Length)];
            GameObject newEnemy = Instantiate(FlyingEnemy, spawnPos);
            newEnemy.transform.parent = null;
        }
    }
    private void SpawnTurretEnemies(int n) 
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-arenaSize.x, arenaSize.x), 0, Random.Range(-arenaSize.y, arenaSize.y));
            GameObject newEnemy = Instantiate(Turrets, spawnPos, new Quaternion());
            newEnemy.transform.parent = null;
        }
    }

    private void SpawnGroundSpawners(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-arenaSize.x, arenaSize.x),0, Random.Range(-arenaSize.y, arenaSize.y));
            Quaternion quaternion = new Quaternion();
            quaternion.eulerAngles = new Vector3(-90, 0, 0);
            GameObject newEnemy = Instantiate(GroundSpawner, spawnPos, quaternion);
            newEnemy.transform.parent = null;
        }
    }
}
