using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform SpawnPoint;
    [SerializeField] int maxNumberOfEnemies;
    [SerializeField] private int numberOfEnemiesAlive;

    private AudioSource audioSource;
    public AudioClip death;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        numberOfEnemiesAlive =0;
    }
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

    public void removeOneEnemyAlive()
    {
        numberOfEnemiesAlive -= 1;
        PlayDeathSound();
    }

    public void PlayDeathSound()
    {
        audioSource.clip = death;
        audioSource.Play();
    }
}
