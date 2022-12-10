using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHPController : MonoBehaviour
{
    [SerializeField] private GameObject enemyParent;
    private Canvas enemyCanvas;
    [SerializeField] Canvas CanvasPrefab;
    private int maxHP = 100;
    private int HealthPoints;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    private SpawningEnemies spawningEnemies;

    private void Awake()
    {
        enemyParent = gameObject;
        enemyCanvas = Instantiate(CanvasPrefab,enemyParent.transform);
        HealthPoints = maxHP;
        healthSlider = enemyCanvas.GetComponentInChildren<Slider>();
        healthSlider.maxValue = maxHP;
        healthSlider.value = maxHP;
        spawningEnemies = enemyParent.GetComponentInParent<SpawningEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCanvas.transform.position = new Vector3(enemyParent.transform.position.x, enemyParent.transform.position.y + 1f, transform.position.z);
    }
    public void updateHealth()
    {
        healthSlider.value = HealthPoints;
        if (healthSlider.value <= 0)
        {
            spawningEnemies.removeOneEnemyAlive();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        HealthPoints -= damage;
        updateHealth();
    }
}
