using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;
    [SerializeField] int maxNumberOfEnemies;
    [SerializeField] private int numberOfEnemiesAlive;
    [SerializeField] private float timeBetweenSpawns;


    private void Awake()
    {
        numberOfEnemiesAlive = 0;
        timeBetweenSpawns = 3f;
    }
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, timeBetweenSpawns);
    }

    private void SpawnEnemy()
    {
        if (maxNumberOfEnemies > numberOfEnemiesAlive)
        {
            Instantiate(enemyPrefab, this.transform);
            numberOfEnemiesAlive++;
        }
    }

    public void removeOneEnemyAlive()
    {
        numberOfEnemiesAlive -= 1;
    }
}
