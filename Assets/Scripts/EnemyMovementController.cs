using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject pukki;
    [SerializeField] private Rigidbody2D rb;
    public float moveSpeed =1f;

    private void Start()
    {
        pukki = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 direction = (pukki.transform.position - transform.position);
        rb.velocity = (transform.position + direction * moveSpeed);
    }
}
