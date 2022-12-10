using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHPController : MonoBehaviour
{
    [SerializeField] private EnemyMovementController enemyMovementController;
    [SerializeField] private GameObject enemyParent;
    private Canvas enemyCanvas;
    [SerializeField] Canvas CanvasPrefab;
    private int EnemyMaxHP = 100;
    private int HealthPoints;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    private SpawningEnemies spawningEnemies;

    private void Awake()
    {
        enemyMovementController = GetComponentInParent<EnemyMovementController>();
        enemyParent = gameObject;
        enemyCanvas = Instantiate(CanvasPrefab,enemyParent.transform);
        HealthPoints = EnemyMaxHP;
        healthSlider = enemyCanvas.GetComponentInChildren<Slider>();
        healthSlider.maxValue = EnemyMaxHP;
        healthSlider.value = EnemyMaxHP;
        spawningEnemies = enemyParent.GetComponentInParent<SpawningEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCanvas.transform.position = new Vector3(enemyParent.transform.position.x, enemyParent.transform.position.y + 1f, transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        enemyMovementController.knockBack();
        HealthPoints -= damage;
        updateHealth();
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

}
