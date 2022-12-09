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
    [SerializeField] private int maxHP;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    }
        void Update()
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, transform.position.z);
        }
    }
