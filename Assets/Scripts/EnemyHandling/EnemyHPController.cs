using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHPController : MonoBehaviour
{
    [SerializeField] private TimerScript timerScript;
    [SerializeField] private float hpMultiplier;
    [SerializeField] private EnemyMovementController enemyMovementController;
    [SerializeField] private GameObject enemyParent;
    private Canvas enemyCanvas;
    [SerializeField] Canvas CanvasPrefab;
    [SerializeField] private int EnemyMaxHP;
    private int HealthPoints;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    private SpawnRegular spawningEnemies;
    [SerializeField] private GameObject splatterAnimParent;
    [SerializeField] private GameObject deathAnimParent;

    private void Awake()
    {
        enemyMovementController = GetComponentInParent<EnemyMovementController>();
        enemyParent = gameObject;
        enemyCanvas = Instantiate(CanvasPrefab, enemyParent.transform);
        healthSlider = enemyCanvas.GetComponentInChildren<Slider>();
        healthText = enemyCanvas.GetComponentInChildren<TMP_Text>();
        spawningEnemies = enemyParent.GetComponentInParent<SpawnRegular>();
    }
    private void Start()
    {
        timerScript = GameObject.FindWithTag("Background").GetComponent<TimerScript>();
        int uusi = (int)(hpMultiplier * timerScript.getTimeFromStart());
        EnemyMaxHP = EnemyMaxHP+uusi;
        HealthPoints = EnemyMaxHP;
        healthSlider.maxValue = EnemyMaxHP;
        healthSlider.value = EnemyMaxHP;
        healthText.text = "HP: " + HealthPoints + " / " + EnemyMaxHP;
    }
    void Update()
    {
        enemyCanvas.transform.position = new Vector3(enemyParent.transform.position.x, enemyParent.transform.position.y + 1f, transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        var splat = Instantiate(splatterAnimParent, transform);
        Destroy(splat, .4f);
        enemyMovementController.knockBack(100f);
        HealthPoints -= damage;
        updateHealth();
    }
    public void updateHealth()
    {
        healthText.text = "HP: " + HealthPoints + " / " + EnemyMaxHP;
        healthSlider.value = HealthPoints;
        if (healthSlider.value <= 1)
        {
            var clone =Instantiate(deathAnimParent, transform);
            clone.transform.parent = null;
            spawningEnemies.removeOneEnemyAlive();
            Destroy(gameObject);
        }
    }

}
