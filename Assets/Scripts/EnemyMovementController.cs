using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private Transform pukki;
    [SerializeField] private Rigidbody2D rb;
    public float moveSpeed =1f;

    private void Start()
    {
        pukki = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(pukki)
        {
            //Vector2 direction = pukki.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position,pukki.position, moveSpeed * Time.deltaTime);
        }
        
    }
}
