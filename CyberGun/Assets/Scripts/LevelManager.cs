using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
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
}
