using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHpController : MonoBehaviour
{
    [SerializeField] private TimerScript timerScript;
    private int hpMultiplier;
    [SerializeField] private EnemyMovementController enemyMovementController;
    [SerializeField] private GameObject enemyParent;
    private Canvas enemyCanvas;
    [SerializeField] Canvas CanvasPrefab;
    private int EnemyMaxHP;
    private int HealthPoints;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    private SpawnBoss spawningEnemies;
    [SerializeField] private GameObject deathAnim;
    [SerializeField] private GameObject splatterAnim;

    private void Awake()
    {
        enemyMovementController = GetComponentInParent<EnemyMovementController>();
        enemyParent = gameObject;
        enemyCanvas = Instantiate(CanvasPrefab, enemyParent.transform);
        healthSlider = enemyCanvas.GetComponentInChildren<Slider>();

        healthText = enemyCanvas.GetComponentInChildren<TMP_Text>();
        spawningEnemies = enemyParent.GetComponentInParent<SpawnBoss>();
    }

    private void Start()
    {
        timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        hpMultiplier = timerScript.getTimeFromStart()*3;
        HealthPoints = EnemyMaxHP = 250 + hpMultiplier;
        healthSlider.maxValue = EnemyMaxHP;
        healthSlider.value = EnemyMaxHP;
        healthText.text = "HP: " + HealthPoints + " / " + EnemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCanvas.transform.position = new Vector3(enemyParent.transform.position.x, enemyParent.transform.position.y + 1f, transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        var splat = Instantiate(splatterAnim, transform);
        Destroy(splat, .4f);
        enemyMovementController.knockBack(15f);
        HealthPoints -= damage;
        updateHealth();
    }
    public void updateHealth()
    {
        healthText.text = "HP: " + HealthPoints + " / " + EnemyMaxHP;
        healthSlider.value = HealthPoints;
        if (healthSlider.value <= 1)
        {
            var clone = Instantiate(deathAnim, transform);
            clone.transform.parent = null;
            spawningEnemies.removeOneEnemyAlive();
            Destroy(gameObject);
        }
    }

}
