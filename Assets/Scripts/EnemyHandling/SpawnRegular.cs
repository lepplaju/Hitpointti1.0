using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRegular : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;
    [SerializeField] int maxNumberOfEnemies;
    [SerializeField] private int numberOfEnemiesAlive;
    [SerializeField] private float timeBetweenSpawns = 10f;

    private void Awake()
    {
        numberOfEnemiesAlive =0;
    }
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, timeBetweenSpawns);
    }

    private void SpawnEnemy()
    {
        if (maxNumberOfEnemies > numberOfEnemiesAlive)
        {
            Instantiate(enemyPrefab, transform);
            numberOfEnemiesAlive++;
        }
    }

    public void removeOneEnemyAlive()
    {
        numberOfEnemiesAlive -= 1;
    }
}
