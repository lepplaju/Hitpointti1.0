using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 10f);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,this.transform);
    }
}
