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
        timeBetweenSpawns = 2f;
        numberOfEnemiesAlive =0;
    }
    private void Start()
    {
        timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        InvokeRepeating("SpawnEnemy", 1f, timeBetweenSpawns);
    }
    private void Update()
    {
        customRepeating();
    }
    private void SpawnEnemy()
    {
        Debug.Log("we are here");
        if (numberOfEnemiesAlive <= 0)
        {
            NextWave();
        }
        if (maxNumberOfEnemies < numberOfEnemiesAlive)
        {
            canSpawn = false;
        }
            if (maxNumberOfEnemies > numberOfEnemiesAlive && canSpawn)
        {
            Instantiate(enemyPrefab, transform);
            numberOfEnemiesAlive++;
        }
    }
    private void NextWave()
    {
        Debug.Log("nextwave!");
        canSpawn = true;
        maxEnemiesAdd =timerScript.getTimeFromStart() / 10;
        maxNumberOfEnemies += maxEnemiesAdd;
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
