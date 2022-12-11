using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRegular : MonoBehaviour
{
    [SerializeField] private TimerScript timerScript;
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;
    [SerializeField] int maxNumberOfEnemies;
    [SerializeField] private int numberOfEnemiesAlive;
    [SerializeField] private float timeBetweenSpawns;
    private int maxEnemiesAdd;
    private bool canSpawn;

    private void Awake()
    {
        maxNumberOfEnemies = 2;
        timeBetweenSpawns = 2f;
        numberOfEnemiesAlive =0;
    }
    private void Start()
    {
        timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        InvokeRepeating("SpawnEnemy", 3f, timeBetweenSpawns);
    }
    private void Update()
    {
        maxNumberOfEnemies = maxNumberOfEnemies + timerScript.getTimeFromStart() / 10;
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

    private void customRepeating()
    {
        //Invoke("SpawnEnemy",)
    }
}
