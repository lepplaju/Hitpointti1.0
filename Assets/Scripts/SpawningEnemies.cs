using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;
    [SerializeField] int maxNumberOfEnemies;
    [SerializeField] int numberOfEnemiesAlive;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 10f);
    }

    private void SpawnEnemy()
    {
        if (maxNumberOfEnemies > numberOfEnemiesAlive)
        {
            Instantiate(enemyPrefab, this.transform);
            numberOfEnemiesAlive++;
        }
    }
}
