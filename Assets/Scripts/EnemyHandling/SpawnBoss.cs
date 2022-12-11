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
    [SerializeField] private TimerScript timerScript;


    private void Awake()
    {
        maxNumberOfEnemies =1;
        numberOfEnemiesAlive = 0;
        timeBetweenSpawns = 3f;
    }
    private void Start()
    {
        timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        InvokeRepeating("SpawnEnemy", 10f, timeBetweenSpawns);
    }

    private void Update()
    {
        maxNumberOfEnemies = maxNumberOfEnemies + timerScript.getTimeFromStart() / 20;
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
