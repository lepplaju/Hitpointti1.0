using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PukkiHPController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private float pukkiMaxHP = 100;
    private float pukkiHP;
    private GameObject playerObj;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        pukkiHP = pukkiMaxHP;
    }
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, transform.position.z);
    }

    private void UpdateHP()
    {
        Debug.Log("taalla ollaan");
        healthSlider.value = pukkiHP;
        if (pukkiHP <= 0) {
            Destroy(playerObj);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damageTaken)
    {
        pukkiHP -= damageTaken;
        UpdateHP();
    }
}
